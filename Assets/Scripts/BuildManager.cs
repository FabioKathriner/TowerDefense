using UnityEngine;
using UnityEngine.EventSystems;
using Quaternion = UnityEngine.Quaternion;

namespace Assets.Scripts
{
    public class BuildManager : MonoBehaviour
    {
        public static BuildManager instance;

        public LayerMask HitMask;
        public LayerMask IgnoreTowerMask;

        private TurretBlueprint _turretToBuild;
        private BuildManager _buildManager;

        private PlayerStats _playerStats;
        private bool _IsInBuildMode;
        private GameObject _selectedTowerPreview;
        private GameObject _selectedTowerPrefab;

        private void Awake()
        {
            if (instance != null)
                Debug.LogError("There is more than one BuildManager in the current scene!");
            instance = this;
        }

        private void Start()
        {
            _playerStats = GetComponent<PlayerStats>();
            _buildManager = BuildManager.instance;
        }

        public void SelectTurretToBuild (TurretBlueprint turretBlueprint)
        { 
            _turretToBuild = turretBlueprint;
        }

        private void FixedUpdate()
        {
            if (!_IsInBuildMode)
                return;

            if (Input.GetMouseButtonDown(1))
            {
                _IsInBuildMode = false;
                Destroy(_selectedTowerPreview);
                _selectedTowerPrefab = null;
                _selectedTowerPreview = null;
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            RaycastHit nonhit;
            if (!Physics.Raycast(ray, out hit, 1000, HitMask))
                return;
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            // TODO: second raycast needed?
            if (Physics.Raycast(ray, out nonhit, 1000, IgnoreTowerMask))
            {
                Debug.LogWarning("Can't place a Turret t this location!");
                return;
            }

            if (_selectedTowerPreview != null)
                _selectedTowerPreview.transform.position = hit.point;

            if (Input.GetMouseButtonDown(0))
            {
                if (_playerStats.Money < _turretToBuild.turretCost)
                {
                    Debug.LogWarning("You don't have enough Money to build that turret!'");
                    return;
                }

                _playerStats.Money -= _turretToBuild.turretCost;
                Destroy(_selectedTowerPreview);
                GameObject turret = Instantiate(_selectedTowerPrefab, hit.point, Quaternion.identity);
                Debug.LogWarning("Turret Placed successfully");
                Debug.Log("Turret built! Money left: " + _playerStats.Money);
            }
        }

        public void EnterBuildMode(GameObject previewPrefab, GameObject actualPrefab)
        {
            _selectedTowerPreview = Instantiate(previewPrefab);
            _selectedTowerPrefab = actualPrefab;
            _IsInBuildMode = true;
        }
    }
}
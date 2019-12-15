using Assets.Scripts.Towers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class BuildManager : MonoBehaviour
    {
        public LayerMask HitMask;
        public LayerMask IgnoreTowerMask;

        private bool _isInBuildMode;
        private GameObject _selectedTowerPreview;
        private GameObject _selectedTowerPrefab;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R) && _selectedTowerPreview != null)
                _selectedTowerPreview.transform.Rotate(Vector3.up, 90f);
        }

        private void FixedUpdate()
        {
            if (!_isInBuildMode)
                return;

            if (Input.GetMouseButton(1))
            {
                Destroy(_selectedTowerPreview);
                LeaveBuildMode();
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            RaycastHit nonhit;
            if (!Physics.Raycast(ray, out hit, 1000, HitMask))
                return;
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (Physics.Raycast(ray, out nonhit, 1000, IgnoreTowerMask))
            {
                Debug.LogWarning("Can't place a Tower at this location!");
                return;
            }

            if (_selectedTowerPreview != null)
            {
                _selectedTowerPreview.transform.position = hit.point;
            }


            if (Input.GetMouseButton(0))
            {
                var buildPrice = _selectedTowerPrefab.GetComponent<Tower>().BuildPrice;
                if (PlayerStats.Money < buildPrice)
                {
                    Debug.LogWarning("You don't have enough Money to build that turret!'");
                    return;
                }

                if (_selectedTowerPreview != null)
                {
                    _selectedTowerPrefab.transform.rotation = _selectedTowerPreview.transform.rotation;
                    Destroy(_selectedTowerPreview);
                }

                GameObject turret = Instantiate(_selectedTowerPrefab, hit.point, _selectedTowerPrefab.transform.rotation);
                PlayerStats.Money -= buildPrice;
                Debug.LogWarning("Tower Placed successfully");
                Debug.Log("Tower built! Money left: " + PlayerStats.Money);
                LeaveBuildMode();
            }
        }

        public void EnterBuildMode(GameObject previewPrefab, GameObject actualPrefab)
        {
            if (_selectedTowerPreview != null)
                Destroy(_selectedTowerPreview);
            _selectedTowerPreview = Instantiate(previewPrefab);
            _selectedTowerPrefab = actualPrefab;
            _isInBuildMode = true;
        }

        private void LeaveBuildMode()
        {
            _isInBuildMode = false;
            _selectedTowerPrefab = null;
            _selectedTowerPreview = null;
        }
    }
}
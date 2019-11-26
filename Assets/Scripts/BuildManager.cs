using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;
using Quaternion = UnityEngine.Quaternion;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public LayerMask HitMask;
    public LayerMask IgnoreTowerMask;

    public GameObject RocketTowerPrefab;
    public GameObject BallisticTowerPrefab;
    public GameObject GuidedMissileTowerPrefab;
    public GameObject BlastTowerPrefab;

    private TurretBlueprint _turretToBuild;
    private BuildManager buildManager;
    private GameObject _turret;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is more than one BuildManager in the current scene!");
        }
        instance = this;
    }

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    
    //Property to check if _turretToBuild is set
    public bool CanBuild {get {return _turretToBuild != null; }}
    

    public void SelectTurretToBuild (TurretBlueprint turretBlueprint)
    { 
      _turretToBuild = turretBlueprint;
    }

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        RaycastHit nonhit;

        if (Physics.Raycast(ray, out hit, 1000, HitMask))
          //  Debug.DrawLine(ray.origin, hit.point);

        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (!buildManager.CanBuild)
                return;

            if (Physics.Raycast(ray, out nonhit, 1000, IgnoreTowerMask))
            {
                Debug.LogWarning("Can't place a Turret on top of another Turret!'");
                return;
            }

            if (PlayerStats.Money < _turretToBuild.turretCost)
            {
                Debug.LogWarning("You don't have enough Money to build that turret!'");
                return;
            }

            PlayerStats.Money -= _turretToBuild.turretCost;

            GameObject turret = (GameObject)Instantiate(_turretToBuild.prefab, hit.point, Quaternion.identity);
            Debug.LogWarning("Turret Placed successfully");
            Debug.Log("Turret built! Money left: " + PlayerStats.Money);
        }
    }

}
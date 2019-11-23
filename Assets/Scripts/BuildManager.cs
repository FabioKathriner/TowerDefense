using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is more than one BuildManager in the current scene!");
        }
        instance = this;
    }

    public GameObject RocketTowerPrefab;
    public GameObject BallisticTowerPrefab;
    public GameObject GuidedMissileTowerPrefab;
    public GameObject BlastTowerPrefab;

    /** void Start()
     {
         _turretToBuild = RocketTowerPrefab;
     }*/

    private GameObject _turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return _turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        _turretToBuild = turret;
    }
  
}
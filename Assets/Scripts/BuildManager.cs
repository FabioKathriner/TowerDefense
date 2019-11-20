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

    public GameObject basicTurretPrefab;

    void Start()
    {
        _turretToBuild = basicTurretPrefab;
    }

    private GameObject _turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return _turretToBuild;
    }
  
}
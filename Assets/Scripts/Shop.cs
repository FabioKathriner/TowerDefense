using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseRocketTower()
    {
        Debug.Log("Rocket Tower selected.");
        buildManager.SetTurretToBuild(buildManager.RocketTowerPrefab);
    }

    public void PurchaseBallisticTower()
    {
        Debug.Log("Ballistic Tower selected.");
        buildManager.SetTurretToBuild(buildManager.BallisticTowerPrefab);
    }

    public void PurchaseGuidedMissileTower()
    {
        Debug.Log("Guided Missle Tower selected.");
        buildManager.SetTurretToBuild(buildManager.GuidedMissileTowerPrefab);
    }

    public void PurchaseBlastTower()
    {
        Debug.Log("Blast Tower selected.");
        buildManager.SetTurretToBuild(buildManager.BlastTowerPrefab);
    }

} 

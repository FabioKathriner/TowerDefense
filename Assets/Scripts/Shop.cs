using Assets.Scripts;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint RocketTower;
    public TurretBlueprint BallisticTower;
    public TurretBlueprint GuidedMissileTower;
    public TurretBlueprint BlastTower;

    private BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectRocketTower()
    {
        Debug.Log("Rocket Tower selected.");
        buildManager.SelectTurretToBuild(RocketTower);
    }

    public void SelectBallisticTower()
    {
        Debug.Log("Ballistic Tower selected.");
        buildManager.SelectTurretToBuild(BallisticTower);
    }

    public void SelectGuidedMissileTower()
    {
        Debug.Log("Guided Missle Tower selected.");
        buildManager.SelectTurretToBuild(GuidedMissileTower);
    }

    public void SelectBlastTower()
    {
        Debug.Log("Blast Tower selected.");
        buildManager.SelectTurretToBuild(BlastTower);
    }

} 

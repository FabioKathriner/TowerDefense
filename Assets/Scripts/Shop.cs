using UnityEngine;

namespace Assets.Scripts
{
    public class Shop : MonoBehaviour
    {

        [SerializeField]
        private GameObject _rocketTower;
        [SerializeField]
        private GameObject _ballisticTower;
        [SerializeField]
        private GameObject _guidedMissileTower;
        [SerializeField]
        private GameObject _blastTower;

        private BuildManager buildManager;

        void Start()
        {
            buildManager = BuildManager.Instance;
        }

        public void SelectRocketTower()
        {
            Debug.Log("Rocket Tower selected.");
            buildManager.SelectTurretToBuild(_rocketTower);
        }

        public void SelectBallisticTower()
        {
            Debug.Log("Ballistic Tower selected.");
            buildManager.SelectTurretToBuild(_ballisticTower);
        }

        public void SelectGuidedMissileTower()
        {
            Debug.Log("Guided Missle Tower selected.");
            buildManager.SelectTurretToBuild(_guidedMissileTower);
        }

        public void SelectBlastTower()
        {
            Debug.Log("Blast Tower selected.");
            buildManager.SelectTurretToBuild(_blastTower);
        }

    }
} 

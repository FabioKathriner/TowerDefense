using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI_Elements.Unit
{
    public class TowerUnitDetails : MonoBehaviour
    {
        [SerializeField]
        private Text _level;
        [SerializeField]
        private Text _health;
        [SerializeField]
        private Text _rateOfFire;
        [SerializeField]
        private Text _damage;
        [SerializeField]
        private Button _targetClosestToBaseButton;
        [SerializeField]
        private Button _targetLowestHealthButton;
        [SerializeField]
        private Button _targetMostHealthButton;
        [SerializeField]
        private GameObject _targetPanel;

        public string Level
        {
            set => _level.text = value;
        }

        public string Health
        {
            set => _health.text = value;
        }

        public string RateOfFire
        {
            set => _rateOfFire.text = value;
        }

        public string Damage
        {
            set => _damage.text = value;
        }

        public Button TargetClosestToBaseButton => _targetClosestToBaseButton;
        public Button TargetLowestHealthButton => _targetLowestHealthButton;
        public Button TargetMostHealthButton => _targetMostHealthButton;
        public GameObject TargetPanel => _targetPanel;
    }
}

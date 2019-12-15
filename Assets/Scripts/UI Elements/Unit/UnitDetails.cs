using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI_Elements.Unit
{
    public class UnitDetails : MonoBehaviour
    {
        [SerializeField]
        private Text _health;

        public string Health
        {
            set => _health.text = value;
        }
    }
}

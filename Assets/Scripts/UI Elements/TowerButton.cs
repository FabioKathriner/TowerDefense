using Assets.Scripts.Towers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI_Elements
{
    [RequireComponent(typeof(Button))]
    public abstract class TowerButton : MonoBehaviour
    {
        private Button _button;

        protected Tower Tower { get; private set; }

        protected virtual void Start()
        {
            Tower = GetComponentInParent<Tower>();
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        protected virtual void OnClick()
        {
            if (Tower != null)
                OnClick(Tower);
        }

        protected abstract void OnClick(Tower tower);
    }
}
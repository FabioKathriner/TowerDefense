using Assets.Scripts.Towers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI_Elements
{
    [RequireComponent(typeof(Button))]
    public abstract class TowerButton : MonoBehaviour
    {
        [SerializeField]
        private Tower _tower; // TODO: Use GetComponentInParent<Tower>();

        private Button _button;

        protected Tower Tower => _tower;

        protected virtual void Start()
        {
            _button = GetComponent<Button>();
            gameObject.SetActive(false);
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
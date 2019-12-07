using Assets.Scripts.Towers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public abstract class TowerButton : MonoBehaviour
    {
        [SerializeField]
        private Text _priceText;

        [SerializeField]
        private Tower _tower;

        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            gameObject.SetActive(false);
            _button.onClick.AddListener(OnClick);
            if (_tower != null)
                _priceText.text = GetNewPrice(_tower);
        }

        private void OnClick()
        {
            if (_tower != null)
            {
                OnClick(_tower);
                _priceText.text = GetNewPrice(_tower);
            }
        }

        protected abstract void OnClick(Tower tower);

        protected abstract string GetNewPrice(Tower tower);
    }
}
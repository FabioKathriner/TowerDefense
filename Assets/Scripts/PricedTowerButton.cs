using Assets.Scripts.Towers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public abstract class PricedTowerButton : TowerButton
    {
        [SerializeField]
        private Text _priceText;

        protected override void Start()
        {
            base.Start();
            if (Tower != null)
                UpdateText(GetNewPrice(Tower));
        }

        protected override void OnClick()
        {
            if (Tower != null)
            {
                OnClick(Tower);
                UpdateText(GetNewPrice(Tower));
            }
        }

        protected void UpdateText(int newPrice)
        {
            _priceText.text = $"{newPrice}$";
        }

        protected abstract int GetNewPrice(Tower tower);
    }
}
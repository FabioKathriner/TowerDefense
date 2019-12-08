using Assets.Scripts.Towers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public abstract class PricedTowerButton : TowerButton
    {
        [SerializeField]
        private Text _priceText;

        protected Text PriceText => _priceText;

        protected override void Start()
        {
            base.Start();
            if (Tower != null)
                PriceText.text = GetNewPrice(Tower);
        }

        protected override void OnClick()
        {
            if (Tower != null)
            {
                OnClick(Tower);
                PriceText.text = GetNewPrice(Tower);
            }
        }

        protected abstract string GetNewPrice(Tower tower);
    }
}
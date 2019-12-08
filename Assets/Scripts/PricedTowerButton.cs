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
                _priceText.text = GetNewPrice(Tower);
        }

        protected override void OnClick()
        {
            if (Tower != null)
            {
                OnClick(Tower);
                _priceText.text = GetNewPrice(Tower);
            }
        }
    }
}
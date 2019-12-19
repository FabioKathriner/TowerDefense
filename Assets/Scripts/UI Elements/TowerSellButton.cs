using System;
using Assets.Scripts.Towers;

namespace Assets.Scripts.UI_Elements
{
    public class TowerSellButton : PricedTowerButton
    {
        protected override void Start()
        {
            base.Start();
            if (Tower != null)
                Tower.OnTotalValueChanged += OnTotalValueChanged;
        }

        private void OnTotalValueChanged(object sender, EventArgs e)
        {
            UpdateText(GetNewPrice(Tower));
        }
        protected override void OnClick(Tower tower)
        {
            tower.Health.Die();
            GameManager.Instance.PlayerStats.Money += GetSellValue(tower);
        }

        protected override int GetNewPrice(Tower tower) => GetSellValue(tower);

        private static int GetSellValue(Tower tower) => tower.TotalValue / 2;
    }
}
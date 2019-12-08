using System;
using Assets.Scripts.Towers;

namespace Assets.Scripts
{
    public class TowerRepairButton : PricedTowerButton
    {
        protected override void Start()
        {
            base.Start();
            if (Tower != null)
                Tower.OnRepairPriceChanged += OnRepairPriceChanged;
        }

        private void OnRepairPriceChanged(object sender, EventArgs e)
        {
            PriceText.text = Tower.RepairPrice.ToString();
        }

        protected override void OnClick(Tower tower)
        {
            PlayerStats.Money -= tower.RepairPrice;
            tower.Repair();
        }

        protected override string GetNewPrice(Tower tower)
        {
            //TODO: create repair price on Tower, remove inheritance
            return tower.RepairPrice.ToString();
        }
    }
}

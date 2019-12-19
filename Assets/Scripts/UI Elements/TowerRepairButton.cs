using System;
using Assets.Scripts.Towers;

namespace Assets.Scripts.UI_Elements
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
            UpdateText(Tower.RepairPrice);
        }

        protected override void OnClick(Tower tower)
        {
            if (GameManager.Instance.PlayerStats.Money >= tower.RepairPrice)
            {
                GameManager.Instance.PlayerStats.Money -= tower.RepairPrice;
                tower.Repair();
            }
            else
            {
                GameManager.Instance.Broadcast($"Insufficient funds! Missing {tower.RepairPrice - GameManager.Instance.PlayerStats.Money}$");
            }
        }

        protected override int GetNewPrice(Tower tower)
        {
            return tower.RepairPrice;
        }
    }
}

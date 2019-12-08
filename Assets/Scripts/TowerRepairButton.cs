using Assets.Scripts.Towers;

namespace Assets.Scripts
{
    public class TowerRepairButton : PricedTowerButton
    {
        protected override void OnClick(Tower tower)
        {
            //TODO: Repair
            tower.Upgrade();
            PlayerStats.Money -= 2;
        }

        protected override string GetNewPrice(Tower tower)
        {
            //TODO: create repair price on Tower, remove inheritance
            return tower.UpgradePrice.ToString();
        }
    }
}

using Assets.Scripts.Towers;

namespace Assets.Scripts
{
    public class TowerUpgradeButton : PricedTowerButton
    {
        protected override void OnClick(Tower tower)
        {
            PlayerStats.Money -= tower.UpgradePrice;
            tower.Upgrade();
        }

        protected override string GetNewPrice(Tower tower)
        {
            return tower.UpgradePrice.ToString();
        }
    }
}

using Assets.Scripts.Towers;

namespace Assets.Scripts.UI_Elements
{
    public class TowerUpgradeButton : PricedTowerButton
    {
        protected override void OnClick(Tower tower)
        {
            PlayerStats.Money -= tower.UpgradePrice;
            tower.Upgrade();
            if (tower.Level >= tower.MaxLevel)
            {
                enabled = false;
                gameObject.SetActive(false);
            }
        }

        protected override int GetNewPrice(Tower tower)
        {
            return tower.UpgradePrice;
        }
    }
}

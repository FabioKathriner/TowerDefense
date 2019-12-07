using Assets.Scripts.Towers;

namespace Assets.Scripts
{
    public class TowerSellButton : TowerButton
    {
        protected override void OnClick(Tower tower)
        {
            tower.Upgrade();
        }

        protected override string GetNewPrice(Tower tower)
        {
            return tower.UpgradePrice.ToString();
        }
    }
}
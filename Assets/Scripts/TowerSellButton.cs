using Assets.Scripts.Towers;

namespace Assets.Scripts
{
    public class TowerSellButton : TowerButton
    {
        protected override string GetNewPrice(Tower selectedTower)
        {
            return selectedTower.UpgradePrice.ToString();
        }
    }
}
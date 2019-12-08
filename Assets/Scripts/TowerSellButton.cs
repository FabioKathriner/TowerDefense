using Assets.Scripts.Towers;

namespace Assets.Scripts
{
    public class TowerSellButton : TowerButton
    {
        protected override void OnClick(Tower tower)
        {
            //TODO: Sell
            Destroy(tower.gameObject);
            PlayerStats.Money += 2;
        }

        protected override string GetNewPrice(Tower tower)
        {
            return tower.UpgradePrice.ToString();
        }
    }
}
using Assets.Scripts.Towers;

namespace Assets.Scripts
{
    public class TowerRepairButton : TowerButton
    {
        protected override void OnClick(Tower tower)
        {
            tower.Upgrade();
        }

        protected override string GetNewPrice(Tower tower)
        {
            //TODO: create repair price on Tower, remove inheritance
            return tower.UpgradePrice.ToString();
        }
    }
}

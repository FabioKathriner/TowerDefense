using Assets.Scripts.Towers;

namespace Assets.Scripts
{
    public class TowerRepairButton : TowerButton
    {
        protected override string GetNewPrice(Tower selectedTower)
        {
            //TODO: create repair price on Tower, remove inheritance
            return selectedTower.UpgradePrice.ToString();
        }
    }
}

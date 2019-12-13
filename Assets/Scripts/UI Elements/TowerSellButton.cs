using Assets.Scripts.Towers;

namespace Assets.Scripts.UI_Elements
{
    public class TowerSellButton : TowerButton
    {
        protected override void OnClick(Tower tower)
        {
            Destroy(tower.gameObject);
            PlayerStats.Money += tower.TotalValue / 2;
        }
    }
}
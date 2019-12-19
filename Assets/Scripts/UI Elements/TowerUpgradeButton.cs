using Assets.Scripts.Towers;

namespace Assets.Scripts.UI_Elements
{
    public class TowerUpgradeButton : PricedTowerButton
    {
        protected override void OnClick(Tower tower)
        {
            if (GameManager.Instance.PlayerStats.Money >= tower.UpgradePrice)
            {
                GameManager.Instance.PlayerStats.Money -= tower.UpgradePrice;
                tower.Upgrade();
                if (tower.Level >= tower.MaxLevel)
                {
                    enabled = false;
                    gameObject.SetActive(false);
                }
            }
            else
            {
                GameManager.Instance.Broadcast($"Insufficient funds! Missing {tower.UpgradePrice - GameManager.Instance.PlayerStats.Money}$");
            }
        }

        protected override int GetNewPrice(Tower tower)
        {
            return tower.UpgradePrice;
        }
    }
}

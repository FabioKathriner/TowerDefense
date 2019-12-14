using Assets.Scripts.UI_Elements;
using UnityEngine;

public class TowerUnitInfo : MonoBehaviour, IUnitInfo
{
    public void Show()
    {
        var towerButtons = gameObject.GetComponentsInChildren<TowerButton>(true);
        foreach (var towerButton in towerButtons)
        {
            if (towerButton.enabled)
            {
                // TODO: Do not show button if not expected (e.g. Sell base)
                towerButton.gameObject.SetActive(true);
            }
        }
    }

    public void Hide()
    {
        var towerButtons = gameObject.GetComponentsInChildren<TowerButton>();
        foreach (var towerButton in towerButtons)
        {
            towerButton.gameObject.SetActive(false);
        }
    }
}
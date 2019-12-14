using Assets.Scripts.Towers;
using Assets.Scripts.UI_Elements;
using UnityEngine;

public class TowerUnitInfo : MonoBehaviour, IUnitInfo
{
    private TargetFinder _selectedTargetFinder;
    private LineRenderer _lineRenderer;
    private const int LineSegments = 50;
    public void Show()
    {
        _selectedTargetFinder = gameObject.GetComponentInParent<TargetFinder>();
        var towerButtons = gameObject.GetComponentsInChildren<TowerButton>(true);
        foreach (var towerButton in towerButtons)
        {
            if (towerButton.enabled)
            {
                // TODO: Do not show button if not expected (e.g. Sell base)
                towerButton.gameObject.SetActive(true);
            }
        }
        DrawTowerRadius();
    }

    public void Hide()
    {
        var towerButtons = gameObject.GetComponentsInChildren<TowerButton>();
        foreach (var towerButton in towerButtons)
        {
            towerButton.gameObject.SetActive(false);
        }
        _lineRenderer.enabled = false;
    }

    private void DrawTowerRadius()
    {
        _lineRenderer = GetComponentInParent<LineRenderer>();
        if (_lineRenderer == null)
        {
            _lineRenderer = _selectedTargetFinder.gameObject.AddComponent<LineRenderer>();
            _lineRenderer.material = Resources.Load<Material>("Materials/Tower Range Preview Color");
            _lineRenderer.widthMultiplier = 0.2f;
            _lineRenderer.useWorldSpace = false;
            _lineRenderer.positionCount = LineSegments + 1;
        }

        float x;
        float z;

        float angle = 20f;

        for (int i = 0; i < (LineSegments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * _selectedTargetFinder.Radius;
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * _selectedTargetFinder.Radius;

            _lineRenderer.SetPosition(i, new Vector3(x, 0.1f, z));

            angle += (360f / LineSegments);
        }
        _lineRenderer.enabled = true;
    }
}
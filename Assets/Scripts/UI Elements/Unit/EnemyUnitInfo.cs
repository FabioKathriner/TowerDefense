using Assets.Scripts.Towers;
using Assets.Scripts.UI_Elements.Unit;
using UnityEngine;

public class EnemyUnitInfo : MonoBehaviour, IUnitInfo
{
    private const int LineSegments = 50;
    [SerializeField]
    private Material _lineRendererMaterial;
    private LineRenderer _lineRenderer;
    private TargetFinder _selectedTargetFinder;

    void Start()
    {
        _selectedTargetFinder = GetComponentInParent<TargetFinder>();
    }

    // TODO: Use RangeDrawer?
    private void DrawTowerRadius(TargetFinder targetFinder)
    {
        _lineRenderer = GetComponentInParent<LineRenderer>();
        if (_lineRenderer == null)
        {
            _lineRenderer = targetFinder.gameObject.AddComponent<LineRenderer>();
            _lineRenderer.material = _lineRendererMaterial;
            _lineRenderer.widthMultiplier = 0.2f;
            _lineRenderer.useWorldSpace = false;
            _lineRenderer.generateLightingData = true;
            _lineRenderer.positionCount = LineSegments + 1;
            float x;
            float z;
            float angle = 20f;
            for (int i = 0; i < (LineSegments + 1); i++)
            {
                x = Mathf.Sin(Mathf.Deg2Rad * angle) * targetFinder.Radius;
                z = Mathf.Cos(Mathf.Deg2Rad * angle) * targetFinder.Radius;

                _lineRenderer.SetPosition(i, new Vector3(x, 0.1f, z));

                angle += (360f / LineSegments);
            }
        }

        _lineRenderer.enabled = true;
    }

    public void Show()
    {
        if (_selectedTargetFinder != null)
            DrawTowerRadius(_selectedTargetFinder);
    }

    public void Hide()
    {
        if (_lineRenderer != null)
            _lineRenderer.enabled = false;
    }
}

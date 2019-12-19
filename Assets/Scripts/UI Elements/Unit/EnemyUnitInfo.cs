using Assets.Scripts.Towers;
using Assets.Scripts.UI_Elements;
using Assets.Scripts.UI_Elements.Unit;
using UnityEngine;

public class EnemyUnitInfo : MonoBehaviour, IUnitInfo
{
    [SerializeField]
    private Material _lineRendererMaterial;
    private TargetFinder _selectedTargetFinder;
    private RangeDrawer _rangeDrawer;

    private void Start()
    {
        _selectedTargetFinder = GetComponentInParent<TargetFinder>();
        if (_selectedTargetFinder != null)
        {
            _rangeDrawer = gameObject.AddComponent<RangeDrawer>();
            _rangeDrawer.Radius = _selectedTargetFinder.Radius;
            _rangeDrawer.Material = _lineRendererMaterial;
            _rangeDrawer.LineRendererObject = _selectedTargetFinder.gameObject;
        }
    }

    public void Show()
    {
        if (_selectedTargetFinder != null)
            _rangeDrawer.Show();
    }

    public void Hide()
    {
        if (_selectedTargetFinder != null)
            _rangeDrawer.Hide();
    }
}

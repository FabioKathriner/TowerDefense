using Assets.Scripts.Towers;
using UnityEngine;

namespace Assets.Scripts.UI_Elements.Unit
{
    public class TowerUnitInfo : MonoBehaviour, IUnitInfo
    {
        [SerializeField]
        private Material _lineRendererMaterial;
        [SerializeField]
        private GameObject _selectionContainer;
        private TargetFinder _selectedTargetFinder;
        private LineRenderer _lineRenderer;
        private Tower _selectedTower;
        private const int LineSegments = 50;

        private void Start()
        {
            _selectedTower = GetComponentInParent<Tower>();
            _selectedTargetFinder = GetComponentInParent<TargetFinder>();
        }

        public void Show()
        {
            _selectionContainer.SetActive(true);
            if (_selectedTargetFinder != null)
                DrawTowerRadius();
        }

        public void Hide()
        {
            _selectionContainer.SetActive(false);
            if (_selectedTargetFinder != null)
                _lineRenderer.enabled = false;
        }

        public void OnTargetClosestToBaseClick() => UpdateTargetingBehaviour(new ClosestToBaseTargetingBehaviour());
        public void OnTargetLowestHealthClick() => UpdateTargetingBehaviour(new LowestHealthTargetingBehaviour());
        public void OnTargetMostHealthClick() => UpdateTargetingBehaviour(new MostHealthTargetingBehaviour());

        private void UpdateTargetingBehaviour(ITargetingBehaviour targetingBehaviour)
        {
            _selectedTargetFinder.TargetingBehaviour = targetingBehaviour;
            Debug.Log($"TargetingBehaviour of {_selectedTower.Name} was changed to {targetingBehaviour.GetType().Name}");
        }

        // TODO: Use RangeDrawer?
        private void DrawTowerRadius()
        {
            _lineRenderer = GetComponentInParent<LineRenderer>();
            if (_lineRenderer == null)
            {
                _lineRenderer = _selectedTargetFinder.gameObject.AddComponent<LineRenderer>();
                _lineRenderer.material = _lineRendererMaterial;
                _lineRenderer.widthMultiplier = 0.2f;
                _lineRenderer.useWorldSpace = false;
                _lineRenderer.generateLightingData = true;
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
}
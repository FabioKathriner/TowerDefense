using System;
using Assets.Scripts.Towers;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI_Elements.Unit
{
    public class TowerUnitInfo : MonoBehaviour, IUnitInfo
    {
        private const int LineSegments = 50;
        private const string ClosestToBaseTargetingBehaviourName = "Closest to Base";
        private const string LowestHealthTargetingBehaviourName = "Lowest Health";
        private const string MostHealthTargetingBehaviourName = "Most Health";

        [SerializeField]
        private Material _lineRendererMaterial;

        [SerializeField]
        private GameObject _selectionContainer;

        [SerializeField]
        private GameObject _targetPanel;

        [SerializeField]
        private Text _selectedTargetBehaviour;

        private TargetFinder _selectedTargetFinder;
        private LineRenderer _lineRenderer;
        private Tower _selectedTower;
        private bool _isShowing;

        private void Start()
        {
            _selectedTower = GetComponentInParent<Tower>();
            _selectedTargetFinder = GetComponentInParent<TargetFinder>();
            _selectionContainer.SetActive(false);
            _selectedTargetBehaviour.text = ClosestToBaseTargetingBehaviourName;
        }

        private void Update()
        {
            if (_isShowing)
            {
                var distance = Vector3.Distance(transform.position, Camera.main.transform.position);
                _selectionContainer.transform.localScale = Vector3.one * Mathf.Clamp(distance / 10, 0.5f, 10f);
            }
        }

        public void Show()
        {
            _isShowing = true;
            _selectionContainer.SetActive(true);
            if (_selectedTargetFinder != null)
                DrawTowerRadius();
            else
                _targetPanel.SetActive(false);
        }

        public void Hide()
        {
            _isShowing = false;
            _selectionContainer.transform.localScale = Vector3.one * 0.03f;
            _selectionContainer.SetActive(false);
            if (_selectedTargetFinder != null)
                _lineRenderer.enabled = false;
        }

        public void OnTargetClosestToBaseClick() => UpdateTargetingBehaviour(new ClosestToBaseTargetingBehaviour(), ClosestToBaseTargetingBehaviourName);
        public void OnTargetLowestHealthClick() => UpdateTargetingBehaviour(new LowestHealthTargetingBehaviour(), LowestHealthTargetingBehaviourName);
        public void OnTargetMostHealthClick() => UpdateTargetingBehaviour(new MostHealthTargetingBehaviour(), MostHealthTargetingBehaviourName);

        private void UpdateTargetingBehaviour(ITargetingBehaviour targetingBehaviour, string updateText)
        {
            _selectedTargetFinder.TargetingBehaviour = targetingBehaviour;
            _selectedTargetBehaviour.text = updateText;
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
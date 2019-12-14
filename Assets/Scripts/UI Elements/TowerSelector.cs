using Assets.Scripts.Towers;
using UnityEngine;

namespace Assets.Scripts.UI_Elements
{

    public class TowerSelector : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _layerMask;

        private GameObject _selectedTower;
        private Renderer _selectedRenderer;
        private Color _previousColor;
        private TargetFinder _selectedTargetFinder;
        private LineRenderer _lineRenderer;
        private const int LineSegments = 50;

        private void FixedUpdate()
        {
            // Clear previous selection on right mouse click
            if (Input.GetMouseButton(1) && _selectedTower != null)
            { 
                ResetPreviousSelection();
                return;
            }

            if (!Input.GetMouseButton(0))
                return;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (!Physics.Raycast(ray, out hitInfo, 1000, _layerMask))
                return;

            if (hitInfo.transform.gameObject.tag == Tags.Tower)
            {
                // Deselect the previous tower and select the clicked one
                ResetPreviousSelection();
                _selectedTower = hitInfo.transform.gameObject;
                _selectedTargetFinder = _selectedTower.GetComponent<TargetFinder>();
                _selectedRenderer = _selectedTower.GetComponentInChildren<Renderer>();
                _previousColor = _selectedRenderer.material.color;
                _selectedRenderer.material.SetColor("_Color", Color.blue);

                DrawTowerRadius();

                var towerButtons = _selectedTower.GetComponentsInChildren<TowerButton>(true);
                foreach (var towerButton in towerButtons)
                {
                    if (towerButton.enabled)
                    {
                        // TODO: Do not show button if not expected (e.g. Sell base)
                        towerButton.gameObject.SetActive(true);
                    }
                }
            }
            else
            {
                // Clear selection on left mouse click somewhere else
                ResetPreviousSelection();
            }
        }

        private void ResetPreviousSelection()
        {
            if (_selectedTower != null)
            {
                var towerButtons = _selectedTower.GetComponentsInChildren<TowerButton>();
                foreach (var towerButton in towerButtons)
                {
                    towerButton.gameObject.SetActive(false);
                }
                _selectedRenderer.material.SetColor("_Color", _previousColor);
                _lineRenderer.enabled = false;
                _selectedTower = null;
            }
        }

        private void DrawTowerRadius()
        {
            _lineRenderer = _selectedTower.GetComponent<LineRenderer>();
            if (_lineRenderer == null)
                _lineRenderer = _selectedTower.AddComponent<LineRenderer>();

            _lineRenderer.widthMultiplier = 0.2f;
            _lineRenderer.endColor = Color.white;
            _lineRenderer.startColor = Color.white;
            _lineRenderer.useWorldSpace = false;
            _lineRenderer.positionCount = LineSegments + 1;

            float x;
            float z;

            float angle = 20f;

            for (int i = 0; i < (LineSegments + 1); i++)
            {
                x = Mathf.Sin(Mathf.Deg2Rad * angle) * _selectedTargetFinder.Radius;
                z = Mathf.Cos(Mathf.Deg2Rad * angle) * _selectedTargetFinder.Radius;

                _lineRenderer.SetPosition(i, new Vector3(x, 0f, z));

                angle += (360f / LineSegments);
            }
            _lineRenderer.enabled = true;
        }
    }
}

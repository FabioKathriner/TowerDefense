using Assets.Scripts.Towers;
using UnityEngine;

namespace Assets.Scripts.UI_Elements
{

    public class UnitSelector : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _layerMask;

        private GameObject _selectedUnit;
        private Renderer _selectedRenderer;
        private Color _previousColor;
        private TargetFinder _selectedTargetFinder;
        private LineRenderer _lineRenderer;
        private IUnitInfo _unitInfo;
        private const int LineSegments = 50;

        private void FixedUpdate()
        {
            // Clear previous selection on right mouse click
            if (Input.GetMouseButton(1) && _selectedUnit != null)
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
                _selectedUnit = hitInfo.transform.gameObject;
                _selectedTargetFinder = _selectedUnit.GetComponent<TargetFinder>();
                _selectedRenderer = _selectedUnit.GetComponentInChildren<MeshRenderer>();
                _previousColor = _selectedRenderer.material.color;
                _selectedRenderer.material.color = Color.blue;

                DrawTowerRadius();
                _unitInfo = _selectedUnit.GetComponentInChildren<IUnitInfo>();
                _unitInfo.Show();
            }
            else
            {
                // Clear selection on left mouse click somewhere else
                ResetPreviousSelection();
            }
        }

        private void ResetPreviousSelection()
        {
            if (_selectedUnit != null)
            {
                _unitInfo.Hide();
                _selectedRenderer.material.color = _previousColor;
                _lineRenderer.enabled = false;
                _selectedUnit = null;
            }
        }

        private void DrawTowerRadius()
        {
            _lineRenderer = _selectedUnit.GetComponent<LineRenderer>();
            if (_lineRenderer == null)
            {
                _lineRenderer = _selectedUnit.AddComponent<LineRenderer>();
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
}

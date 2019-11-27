using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
    public class TowerSelector : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _layerMask;

        private GameObject _selectedTower;
        private Renderer _selectedRenderer;
        private Color _previousColor;

        private void FixedUpdate()
        {
            if (!Input.GetMouseButtonDown(0))
                return;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (!Physics.Raycast(ray, out hitInfo, 1000, _layerMask))
                return;

            if (hitInfo.transform.gameObject.tag == Tags.Tower)
            {
                ResetPreviousSelection();
                _selectedTower = hitInfo.transform.gameObject;
                _selectedRenderer = _selectedTower.GetComponentInChildren<Renderer>();
                _previousColor = _selectedRenderer.material.color;
                _selectedRenderer.material.SetColor("_Color", Color.blue);
            }
        }

        private void ResetPreviousSelection()
        {
            if (_selectedTower != null)
            {
                _selectedRenderer.material.SetColor("_Color", _previousColor);
            }
        }
    }
}

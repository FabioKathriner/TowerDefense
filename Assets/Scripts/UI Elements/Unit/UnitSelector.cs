using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI_Elements.Unit
{

    public class UnitSelector : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _layerMask;

        private GameObject _selectedUnit;
        private IUnitInfo _unitInfo;
        private readonly IDictionary<MeshRenderer, Color> _selectedRenderers = new Dictionary<MeshRenderer, Color>();
        public event EventHandler<UnitSelectionEventArgs> OnUnitSelected;
        public event EventHandler<UnitSelectionEventArgs> OnUnitDeselected;

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

            // Deselect the previous tower and select the clicked one
            ResetPreviousSelection();
            _selectedUnit = hitInfo.transform.gameObject;
            var meshRenderers = _selectedUnit.GetComponentsInChildren<MeshRenderer>();
            foreach (var meshRenderer in meshRenderers)
            {
                _selectedRenderers[meshRenderer] = meshRenderer.material.color;
                meshRenderer.material.color = Color.blue;
            }

            _unitInfo = _selectedUnit.GetComponentInChildren<IUnitInfo>();
            _unitInfo?.Show();
            OnUnitSelected?.Invoke(this, new UnitSelectionEventArgs(_selectedUnit));
            _selectedUnit.GetComponent<IUnit>().Health.OnDie += OnSelectedUnitDied;
        }

        private void OnSelectedUnitDied(object sender, EventArgs e)
        {
            ResetPreviousSelection();
        }

        private void ResetPreviousSelection()
        {
            if (_selectedUnit != null)
            {
                _unitInfo?.Hide();
                foreach (var previousRendererColor in _selectedRenderers)
                {
                    if (previousRendererColor.Key != null)
                        previousRendererColor.Key.material.color = previousRendererColor.Value;
                }
                _selectedRenderers.Clear();
                OnUnitDeselected?.Invoke(this, new UnitSelectionEventArgs(_selectedUnit));
                _selectedUnit = null;
            }
        }
    }

    public class UnitSelectionEventArgs : EventArgs
    {
        public UnitSelectionEventArgs(GameObject unit)
        {
            Unit = unit;
        }

        public GameObject Unit { get; }
    }
}

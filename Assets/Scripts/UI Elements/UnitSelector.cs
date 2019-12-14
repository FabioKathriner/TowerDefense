﻿using Assets.Scripts.Towers;
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
        private IUnitInfo _unitInfo;

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
            _selectedRenderer = _selectedUnit.GetComponentInChildren<MeshRenderer>();
            _previousColor = _selectedRenderer.material.color;
            _selectedRenderer.material.color = Color.blue;

            _unitInfo = _selectedUnit.GetComponentInChildren<IUnitInfo>();
            _unitInfo?.Show();
        }

        private void ResetPreviousSelection()
        {
            if (_selectedUnit != null)
            {
                _unitInfo?.Hide();
                _selectedRenderer.material.color = _previousColor;
                _selectedUnit = null;
            }
        }
    }
}

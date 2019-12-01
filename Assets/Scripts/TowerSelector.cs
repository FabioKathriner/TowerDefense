using UnityEngine;

namespace Assets.Scripts
{

    public class TowerSelector : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _layerMask;

        private GameObject _selectedTower;
        private Renderer _selectedRenderer;
        private Color _previousColor;
        public event TowerSelected OnTowerSelected;
        public event TowerDeselected OnTowerDeselected;
        public delegate void TowerSelected(object sender, TowerSelectedArgs args);
        public delegate void TowerDeselected(object sender);

        private void FixedUpdate()
        {
            if (Input.GetMouseButton(1) && _selectedTower != null)
            { 
                ResetPreviousSelection();
                OnTowerDeselected?.Invoke(this);
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
                ResetPreviousSelection();
                _selectedTower = hitInfo.transform.gameObject;
                _selectedRenderer = _selectedTower.GetComponentInChildren<Renderer>();
                _previousColor = _selectedRenderer.material.color;
                _selectedRenderer.material.SetColor("_Color", Color.blue);
                OnTowerSelected?.Invoke(this, new TowerSelectedArgs(_selectedTower));
            }
            else
            {
                ResetPreviousSelection();
                OnTowerDeselected?.Invoke(this);
            }
        }

        private void ResetPreviousSelection()
        {
            if (_selectedTower != null)
            {
                _selectedRenderer.material.SetColor("_Color", _previousColor);
                _selectedTower = null;
            }
        }
    }

    public class TowerSelectedArgs
    {
        public TowerSelectedArgs(GameObject selectedTower)
        {
            SelectedTower = selectedTower;
        }

        public GameObject SelectedTower { get; set; }
    }
}

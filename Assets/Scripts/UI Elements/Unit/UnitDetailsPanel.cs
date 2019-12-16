using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI_Elements.Unit
{
    public class UnitDetailsPanel : MonoBehaviour
    {
        [SerializeField]
        private Text _unitName;
        private UnitSelector _unitSelector;
        private GameObject _unitDetailsCanvas;
        private IUnitDetailsProvider _unitDetails;

        private void Awake()
        {
            _unitSelector = GameManager.Instance.UnitSelector;
            _unitSelector.OnUnitSelected += OnUnitSelected;
            _unitSelector.OnUnitDeselected += OnUnitDeselected;
            gameObject.SetActive(false);
        }

        // TODO: UpdateDetails should be called after the values actually changed by using events
        private void LateUpdate()
        {
            if (_unitDetails != null && _unitDetailsCanvas != null)
                _unitDetails.UpdateDetails(_unitDetailsCanvas);
        }

        private void OnUnitSelected(object sender, UnitSelectionEventArgs e)
        {
            _unitDetails = e.Unit.GetComponent<IUnitDetailsProvider>();
            _unitName.text = _unitDetails.GetUnitName();
            var detailsPrefab = _unitDetails.GetDetailsPrefab();
            if (_unitDetailsCanvas == null)
            {
                _unitDetailsCanvas = Instantiate(detailsPrefab, transform);
            }
            else
            {
                Destroy(_unitDetailsCanvas);
                _unitDetailsCanvas = Instantiate(detailsPrefab, transform);
                _unitDetails.UpdateDetails(_unitDetailsCanvas);
            }

            gameObject.SetActive(true);
        }

        private void OnUnitDeselected(object sender, UnitSelectionEventArgs e)
        {
            _unitDetails = null;
            gameObject.SetActive(false);
        }
    }
}

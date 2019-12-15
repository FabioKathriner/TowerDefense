using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI_Elements
{
    public class UnitDetailsPanel : MonoBehaviour
    {
        [SerializeField]
        private Text _unitName;
        private UnitSelector _unitSelector;
        private GameObject _unitDetailsCanvas;

        private void Awake()
        {
            _unitSelector = GameManager.Instance.UnitSelector;
            _unitSelector.OnUnitSelected += OnUnitSelected;
            _unitSelector.OnUnitDeselected += OnUnitDeselected;
            gameObject.SetActive(false);
        }

        private void OnUnitSelected(object sender, UnitSelectionEventArgs e)
        {
            var unitDetails = e.Unit.GetComponent<IUnitDetailsProvider>();
            _unitName.text = unitDetails.GetUnitName();
            var detailsPrefab = unitDetails.GetDetailsPrefab();
            if (_unitDetailsCanvas == null)
                _unitDetailsCanvas = Instantiate(detailsPrefab, transform);
            else
                unitDetails.UpdateDetails(_unitDetailsCanvas);

            gameObject.SetActive(true);
        }

        private void OnUnitDeselected(object sender, UnitSelectionEventArgs e)
        {
            gameObject.SetActive(false);
        }
    }
}

using Assets.Scripts.Towers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class TowerUpgradeButton : MonoBehaviour
    {
        [SerializeField]
        private TowerSelector _towerSelector;
        [SerializeField]
        private TextUpdater _priceText;

        private Button _button;
        private Tower _selectedTower;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.enabled = false;
            _button.onClick.AddListener(OnClick);
            _towerSelector.OnTowerSelected += OnTowerSelected;
            _towerSelector.OnTowerDeselected += OnTowerDeselected;
        }

        private void OnTowerSelected(object sender, TowerSelectedArgs args)
        {
            _button.enabled = true;
            _selectedTower = args.SelectedTower.GetComponent<Tower>();
            _priceText.UpdateText(_selectedTower.UpgradePrice.ToString());
        }

        private void OnTowerDeselected(object sender)
        {
            _button.enabled = false;
            _selectedTower = null;
        }

        private void OnClick()
        {
            if (_selectedTower != null)
            {
                _selectedTower.Upgrade();
                _priceText.UpdateText(_selectedTower.UpgradePrice.ToString());
            }
        }
    }
}

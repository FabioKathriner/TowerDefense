using Assets.Scripts.Towers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public abstract class TowerButton : MonoBehaviour
    {
        [SerializeField]
        private Text _priceText;

        [SerializeField]
        private TowerSelector _towerSelector;

        private Button _button;
        private Tower _selectedTower;

        public TowerSelector TowerSelector
        {
            get => _towerSelector;
            set
            {
                _towerSelector = value;
                _towerSelector.OnTowerSelected += OnTowerSelected;
                _towerSelector.OnTowerDeselected += OnTowerDeselected;
            }
        }

        private void Start()
        {
            _button = GetComponent<Button>();
            gameObject.SetActive(false);
            _button.onClick.AddListener(OnClick);
        }

        private void OnDestroy()
        {
            TowerSelector.OnTowerSelected -= OnTowerSelected;
            TowerSelector.OnTowerDeselected -= OnTowerDeselected;
        }
        private void OnTowerSelected(object sender, TowerSelectedArgs args)
        {
            gameObject.SetActive(true);
            _selectedTower = args.SelectedTower.GetComponent<Tower>();
            _priceText.text = _selectedTower.UpgradePrice.ToString();
        }

        private void OnTowerDeselected(object sender)
        {
            gameObject.SetActive(false);
            _selectedTower = null;
        }

        private void OnClick()
        {
            if (_selectedTower != null)
            {
                _selectedTower.Upgrade();
                _priceText.text = GetNewPrice(_selectedTower);
            }
        }

        protected abstract string GetNewPrice(Tower selectedTower);
    }
}
using Assets.Scripts.Towers;
using UnityEngine;

namespace Assets.Scripts.UI_Elements.Unit
{
    [RequireComponent(typeof(Tower))]
    public class TowerUnitDetailsProvider : MonoBehaviour, IUnitDetailsProvider
    {
        [SerializeField]
        private GameObject _detailsPrefab;
        private IWeaponizedTower _tower;

        private void Awake()
        {
            _tower = GetComponent<IWeaponizedTower>();
        }

        public GameObject GetDetailsPrefab()
        {
            UpdateDetails(_detailsPrefab);
            return _detailsPrefab;
        }

        public string GetUnitName()
        {
            return _tower.Name;
        }

        public void UpdateDetails(GameObject unitDetailsCanvas)
        {
            var unitDetails = unitDetailsCanvas.GetComponent<TowerUnitDetails>();
            unitDetails.Level = $"Level: {_tower.Level}";
            unitDetails.Health = $"Health: {_tower.Health.CurrentHealth} / {_tower.Health.MaxHealth}";
            unitDetails.RateOfFire = $"Rate of fire: {_tower.RateOfFire}";
            unitDetails.Damage = $"Damage: {_tower.GetWeapon().AttackDamage}";
            if (_tower.TargetFinder != null)
            {
                unitDetails.TargetPanel.SetActive(true);
                unitDetails.TargetClosestToBaseButton.onClick.AddListener(() => UpdateTargetingBehaviour(new ClosestToBaseTargetingBehaviour()));
                unitDetails.TargetLowestHealthButton.onClick.AddListener(() => UpdateTargetingBehaviour(new LowestHealthTargetingBehaviour()));
                unitDetails.TargetMostHealthButton.onClick.AddListener(() => UpdateTargetingBehaviour(new MostHealthTargetingBehaviour()));
            }
            else
            {
                unitDetails.TargetPanel.SetActive(false);
            }
        }

        private void UpdateTargetingBehaviour(ITargetingBehaviour targetingBehaviour)
        {
            _tower.TargetFinder.TargetingBehaviour = targetingBehaviour;
            Debug.Log($"TargetingBehaviour of {_tower.Name} was changed to {targetingBehaviour.GetType().Name}");
        }
    }
}
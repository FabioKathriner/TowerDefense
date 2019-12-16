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
        }
    }
}
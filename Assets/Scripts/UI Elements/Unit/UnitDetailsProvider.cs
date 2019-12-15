using UnityEngine;

namespace Assets.Scripts.UI_Elements.Unit
{
    [RequireComponent(typeof(Health.Health))]
    public class UnitDetailsProvider : MonoBehaviour, IUnitDetailsProvider
    {
        [SerializeField]
        private GameObject _detailsPrefab;
        private Health.Health _health;

        private void Awake()
        {
            _health = GetComponent<Health.Health>();
        }

        public GameObject GetDetailsPrefab()
        {
            UpdateDetails(_detailsPrefab);
            return _detailsPrefab;
        }

        public string GetUnitName()
        {
            return gameObject.name;
        }

        public void UpdateDetails(GameObject unitDetailsCanvas)
        {
            var unitDetails = unitDetailsCanvas.GetComponent<UnitDetails>();
            unitDetails.Health = $"Health: {_health.CurrentHealth} / {_health.MaxHealth}";
        }
    }
}
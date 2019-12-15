using Assets.Scripts.Enemies;
using Assets.Scripts.UI_Elements.Unit;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Health.Health))]
    public class Base : MonoBehaviour, IUnit
    {
        public Health.Health Health { get; private set; }
        public static Base Instance { get; private set; }

        private void Awake()
        {
            Health = GetComponent<Health.Health>();
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Debug.LogWarning($"There is more than one {nameof(Base)} in the current scene!");
                Destroy(gameObject);
            }
        }

        // Collision only with Layers "Normal Enemy" and "Flying Enemy"
        void OnTriggerEnter(Collider other)
        {
            Debug.Log("Enemy reached the base");
            var enemy = other.GetComponentInParent<Enemy>();
            if (enemy != null)
            {
                Health.TakeDamage(enemy.AttackPower);
                var enemyHp = enemy.GetComponent<Health.Health>();
                enemyHp.Die();
            }
        }
    }
}

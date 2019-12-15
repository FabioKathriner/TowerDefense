using Assets.Scripts.Enemies;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Health.Health))]
    public class Base : MonoBehaviour, IUnit
    {
        public Health.Health Health { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            Health = GetComponent<Health.Health>();;
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

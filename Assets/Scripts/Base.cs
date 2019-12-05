using Assets.Scripts.Enemies;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Health.Health))]
    public class Base : MonoBehaviour
    {
        private Health.Health _hp;

        // Start is called before the first frame update
        void Start()
        {
            _hp = GetComponent<Health.Health>();;
        }

        // Update is called once per frame
        void Update()
        {

        }


        // Collision only with Layers "Normal Enemy" and "Flying Enemy"
        void OnTriggerEnter(Collider other)
        {
            Debug.Log("Enemy reached the base");
            var enemy = other.GetComponentInParent<Enemy>();
            if (enemy != null)
            {
                _hp.TakeDamage(enemy.AttackPower);
                var enemyHp = enemy.GetComponent<Health.Health>();
                enemyHp.Die();
            }
        }
    }
}

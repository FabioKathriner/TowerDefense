using UnityEngine;

namespace Assets.Scripts.Weapons.Projectiles
{
    public class Rocket : Projectile
    {
        [SerializeField]
        private float _explosionRadius = 2f;

        private void FixedUpdate()
        {
            transform.Translate(Vector3.forward * Speed * Time.fixedDeltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var enemies = GameObject.FindGameObjectsWithTag(Tags.Enemy);
            foreach (var enemy in enemies)
            {
                var enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
                if (enemyDistance > _explosionRadius)
                    continue;

                var health = enemy.GetComponent<Health.Health>();
                if (health != null)
                    health.TakeDamage(Damage);

                Destroy(gameObject);
            }
        }
    }
}
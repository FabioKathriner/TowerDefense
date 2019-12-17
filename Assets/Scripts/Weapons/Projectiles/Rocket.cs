using UnityEngine;

namespace Assets.Scripts.Weapons.Projectiles
{
    [RequireComponent(typeof(ParticleEffect))]
    public class Rocket : Projectile
    {
        [SerializeField]
        private float _explosionRadius = 2f;

        private ParticleEffect _explosionEffect;

        private void Awake()
        {
            _explosionEffect = GetComponent<ParticleEffect>();
        }

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
            }

            _explosionEffect.Explode();
            Destroy(gameObject);
        }
    }
}
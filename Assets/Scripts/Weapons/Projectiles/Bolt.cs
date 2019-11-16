using UnityEngine;

namespace Assets.Scripts.Weapons.Projectiles
{
    public class Bolt : Projectile
    {
        private Rigidbody _rb;
        private bool _hasHitSomething;

        protected override void Start()
        {
            base.Start();
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (!_hasHitSomething && _rb.velocity != Vector3.zero)
            {
                // update bolt rotation to match the trajectory.
                transform.rotation = Quaternion.LookRotation(_rb.velocity);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            _hasHitSomething = true;
            var health = collision.gameObject.GetComponent<Health.Health>();
            if (health != null)
                health.TakeDamage(Damage);

            Destroy(gameObject);
        }
    }
}
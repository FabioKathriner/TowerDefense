using UnityEngine;

namespace Assets.Scripts.Weapons.Projectiles
{
    public class SeekingMissile : Projectile
    {
        private void FixedUpdate()
        {
            if (Target != null)
                transform.LookAt(Target.transform);

            transform.Translate(Vector3.forward * Speed * Time.fixedDeltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var health = collision.gameObject.GetComponent<Health.Health>();
            if (health != null)
                health.TakeDamage(Damage);

            Destroy(gameObject);
        }
    }
}
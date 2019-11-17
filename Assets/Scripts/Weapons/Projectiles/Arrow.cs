using UnityEngine;

namespace Assets.Scripts.Weapons.Projectiles
{
    public class Arrow : Projectile
    {
        private void FixedUpdate()
        {
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
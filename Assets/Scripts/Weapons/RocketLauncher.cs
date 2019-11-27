using Assets.Scripts.Weapons.Projectiles;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class RocketLauncher : ProjectileWeapon
    {
        [SerializeField]
        private float _forwardOffset = 0.5f;

        public override void Fire(GameObject target)
        {
            if (target == null)
                return;

            transform.LookAt(target.transform);
            var projectile = Instantiate(ProjectilePrefab, transform.position + Vector3.forward * _forwardOffset, transform.rotation);
            var script = projectile.GetComponent<Rocket>();
            if (script != null)
                script.Target = target;
        }
    }
}

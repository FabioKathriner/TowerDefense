using Assets.Scripts.Weapons.Projectiles;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class RocketLauncher : ProjectileWeapon
    {
        private Animator _animation;

        protected override void Start()
        {
            base.Start();
            _animation = GetComponentInChildren<Animator>();
        }

        public override void Fire(GameObject target)
        {
            if (target == null)
                return;

            transform.LookAt(target.transform);
            var projectile = Instantiate(ProjectilePrefab, _spawnPointObject.transform.position, transform.rotation);
            var script = projectile.GetComponent<Rocket>();
            _animation.SetTrigger("Fire");
            if (script != null)
                script.Target = target;
        }
    }
}

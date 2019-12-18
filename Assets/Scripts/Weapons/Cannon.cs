using Assets.Scripts.Weapons.Projectiles;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Cannon : ProjectileWeapon
    {
        public override void Fire(GameObject target)
        {
            if (target == null)
                return;

            transform.LookAt(target.transform);
            PlayAnimation();
            var projectile = Instantiate(ProjectilePrefab, _spawnPointObject.transform.position, transform.rotation);
            var script = projectile.GetComponent<GuidedMissile>();
            if (script != null)
                script.Target = target;
        }
    }
}

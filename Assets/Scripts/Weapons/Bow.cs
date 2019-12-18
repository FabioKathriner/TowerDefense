using Assets.Scripts.Weapons.Projectiles;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Bow : ProjectileWeapon
    {
        public override void Fire(GameObject target)
        {
            if (target == null)
                return;

            transform.LookAt(target.transform);
            PlayAnimation();
            var projectile = Instantiate(ProjectilePrefab, _spawnPointObject.transform.position, transform.rotation);
            var arrow = projectile.GetComponent<Arrow>();
            if (arrow != null)
                arrow.Target = target;
        }
    }
}
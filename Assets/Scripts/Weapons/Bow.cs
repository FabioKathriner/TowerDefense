using Assets.Scripts.Weapons.Projectiles;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Bow : ProjectileWeapon
    {
        [SerializeField]
        private Vector3 _spawnOffset = Vector3.forward * 0.5f;

        public override void Fire(GameObject target)
        {
            if (target == null)
                return;

            transform.LookAt(target.transform);
            var projectile = Instantiate(ProjectilePrefab, transform.position + _spawnOffset, transform.rotation);
            var arrow = projectile.GetComponent<Arrow>();
            if (arrow != null)
                arrow.Target = target;
        }
    }
}
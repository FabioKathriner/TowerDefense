using Assets.Scripts.Weapons.Projectiles;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public abstract class ProjectileWeapon : Weapon
    {
        public override int AttackDamage
        {
            get => _attackDamage;
            set
            {
                _attackDamage = value;
                _projectile.Damage = _attackDamage;
            }
        }

        [SerializeField]
        protected GameObject ProjectilePrefab;

        private int _attackDamage;
        private Projectile _projectile;

        protected virtual void Start()
        {
            Debug.Assert(ProjectilePrefab != null);
            if (ProjectilePrefab != null)
            {
                _projectile = ProjectilePrefab.GetComponent<Projectile>();
                AttackDamage = _projectile.Damage;
            }
        }

        public abstract void Fire(GameObject target);
    }
}
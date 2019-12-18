using Assets.Scripts.Weapons.Projectiles;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public abstract class ProjectileWeapon : Weapon
    {
        private Animator _animator;
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

        [SerializeField]
        protected GameObject _spawnPointObject;

        private int _attackDamage;
        private Projectile _projectile;

        protected virtual void Start()
        {
            Debug.Assert(ProjectilePrefab != null);
            _animator = GetComponentInChildren<Animator>();
            if (ProjectilePrefab != null)
            {
                _projectile = ProjectilePrefab.GetComponent<Projectile>();
                AttackDamage = _projectile.Damage;
            }
        }

        protected void PlayAnimation()
        {
            if (_animator != null)
                _animator.SetTrigger("Fire");
        }

        public abstract void Fire(GameObject target);
    }
}
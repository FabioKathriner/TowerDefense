using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class ElectroShocker : Weapon, IAoeWeapon
    {
        [SerializeField]
        private int _attackDamage = 10;

        public void Fire(GameObject target)
        {
            if (target == null)
                return;
            var health = target.GetComponentInParent<Health.Health>();
            if (health != null)
                health.TakeDamage(AttackDamage);
        }

        public void Fire(List<GameObject> targets)
        {
            Debug.Log("Fire electroshocker");
            foreach (var target in targets)
            {
                Fire(target);
            }
        }

        public override int AttackDamage
        {
            get => _attackDamage;
            set => _attackDamage = value;
        }
    }
}
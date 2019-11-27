using System;
using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.Towers
{
    public class BallisticTower : Tower<Ballista>
    {
        public override void Upgrade()
        {
            base.Upgrade();
            RateOfFire -= RateOfFireUpgradeIncrement;
            Health.MaxHealth += HealthUpgradeIncrement;
            Health.CurrentHealth = Health.MaxHealth;
            Weapon.AttackDamage += DamageUpgradeIncrement;
        }

        protected override void Fire()
        {
            Weapon.Fire(null);
        }
    }
}
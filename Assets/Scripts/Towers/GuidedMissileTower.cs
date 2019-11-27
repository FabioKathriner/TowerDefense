using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.Towers
{
    public class GuidedMissileTower : Tower<Cannon>
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
            var nearestTarget = TargetFinder.GetNextTarget();
            if (nearestTarget != null)
                Weapon.Fire(nearestTarget);
        }
    }
}

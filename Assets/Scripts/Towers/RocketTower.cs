using Assets.Scripts.Weapons;

namespace Assets.Scripts.Towers
{
    public class RocketTower : Tower<RocketLauncher>
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

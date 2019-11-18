using System;
using Assets.Scripts.Weapons;

namespace Assets.Scripts.Towers
{
    public class BallisticTower : Tower<Ballista>
    {
        public override void Upgrade()
        {
            throw new NotImplementedException();
        }

        protected override void Fire()
        {
            Weapon.Fire();
        }
    }
}
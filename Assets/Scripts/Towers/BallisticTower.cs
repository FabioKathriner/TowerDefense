using System;
using Assets.Scripts.Weapons;

namespace Assets.Scripts.Towers
{
    public class BallisticTower : Tower<ISimpleWeapon>
    {
        public override void Upgrade()
        {
            throw new NotImplementedException();
        }

        // Start is called before the first frame update
        protected override void Start()
        {
            Weapon = GetComponentInChildren<Ballista>();
        }

        protected override void Fire()
        {
            Weapon.Fire();
        }
    }
}
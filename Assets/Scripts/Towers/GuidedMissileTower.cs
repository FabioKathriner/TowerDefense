﻿using Assets.Scripts.Weapons;

namespace Assets.Scripts.Towers
{
    public class GuidedMissileTower : Tower<IWeapon>
    {

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            Weapon = GetComponentInChildren<Cannon>();
        }

        public override void Upgrade()
        {
            throw new System.NotImplementedException(); 
        }
    }
}
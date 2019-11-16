﻿using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.Towers
{
    public class BallisticTower : Tower<ISimpleWeapon>
    {
        private float _time;
        // Start is called before the first frame update
        public override void Upgrade()
        {
            throw new System.NotImplementedException();
        }

        protected override void Start()
        {
            base.Start();
            Weapon = GetComponentInChildren<Ballista>();
        }

        protected override void Update()
        {
            // TODO: Refactor Towers, add aiming behavior
            _time += Time.deltaTime;

            if (_time >= RateOfFire)
            {
                _time = 0;
                Weapon.Fire();
            }
        }
    }
}
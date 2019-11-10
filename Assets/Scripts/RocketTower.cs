﻿using UnityEngine;

namespace Assets.Scripts
{
    public class RocketTower : Tower
    {
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            Weapon = GetComponentInChildren<RocketLauncher>();
        }

        public override void Upgrade()
        {
            throw new System.NotImplementedException();
        }
    }
}

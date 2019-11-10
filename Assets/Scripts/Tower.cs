﻿using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(TargetFinder))]
    [RequireComponent(typeof(IWeapon))]
    public abstract class Tower : MonoBehaviour, IUpgradable
    {
        private float _time;

        [SerializeField]
        protected float RateOfFire = 0.8f;

        protected TargetFinder TargetFinder;

        public IWeapon Weapon { get; set; }

        public int Level { get; set; }
        public abstract void Upgrade();
        // Start is called before the first frame update
        protected virtual void Start()
        {
            TargetFinder = GetComponentInChildren<TargetFinder>();
        }


        // Update is called once per frame
        protected virtual void Update()
        {
            var nearestTarget = TargetFinder.GetNextTarget();
            if (nearestTarget != null)
            {
                _time += Time.deltaTime;

                if (_time >= RateOfFire)
                {
                    _time = 0;
                    Weapon.Fire(nearestTarget);
                }
            }
        }
    }
}
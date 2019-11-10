using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class BallisticTower : Tower
    {
        [SerializeField]
        private float _rateOfFire = 0.8f;

        private TargetFinder _targetFinder;
        private float _time = 0.0f;

        // Start is called before the first frame update
        void Start()
        {
            _targetFinder = GetComponentInChildren<TargetFinder>();
            Weapon = GetComponentInChildren<Cannon>();
        }

        // Update is called once per frame
        void Update()
        {
            var nearestTarget = _targetFinder.GetNextTarget();
            if (nearestTarget != null)
            {
                _time += Time.deltaTime;

                if (_time >= _rateOfFire)
                {
                    _time = 0;
                    Weapon.Fire(nearestTarget);
                }
            }
        }

        public override void Upgrade()
        {
            throw new System.NotImplementedException(); 
        }
    }
}

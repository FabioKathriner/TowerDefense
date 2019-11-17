using Assets.Scripts.Towers;
using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class TankEnemy : Enemy
    {
        private TargetFinder _targetFinder;
        private float _time;

        [SerializeField]
        protected float RateOfFire = 1.2f;
        private IWeapon _weapon;

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            _targetFinder = GetComponentInChildren<TargetFinder>();
            _weapon = GetComponentInChildren<Bow>();
        }

        // Update is called once per frame
        private void Update()
        {
            _time += Time.deltaTime;

            if (_time >= RateOfFire)
            {
                _time = 0;
                var nearestTarget = _targetFinder.GetNextTarget();
                if (nearestTarget != null)
                    _weapon.Fire(nearestTarget);
            }
        }
    }
}
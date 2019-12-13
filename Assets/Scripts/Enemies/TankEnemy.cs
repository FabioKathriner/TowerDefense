using Assets.Scripts.Towers;
using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class TankEnemy : Enemy
    {
        private TargetFinder _targetFinder;
        private float _timeSinceLastRangedAttack;

        [SerializeField]
        private float _rateOfFire = 1.2f;
        private ProjectileWeapon _weapon;

        // Start is called before the first frame update
        private void Start()
        {
            _targetFinder = GetComponent<TargetFinder>();
            _targetFinder.TargetTags.AddRange(new []{ Tags.Tower });
            _weapon = GetComponentInChildren<Bow>();
        }

        // Update is called once per frame
        private void Update()
        {
            _timeSinceLastRangedAttack += Time.deltaTime;

            if (_timeSinceLastRangedAttack >= _rateOfFire)
            {
                _timeSinceLastRangedAttack = 0;
                var nearestTarget = _targetFinder.GetNextTarget();
                if (nearestTarget != null)
                    _weapon.Fire(nearestTarget);
            }
        }
    }
}
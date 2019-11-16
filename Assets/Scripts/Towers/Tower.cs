using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.Towers
{
    [RequireComponent(typeof(IWeapon))]
    public abstract class Tower<TWeapon> : MonoBehaviour, IUpgradable
        where TWeapon : IWeapon
    {
        private float _time;

        [SerializeField]
        protected float RateOfFire = 0.8f;

        protected TargetFinder TargetFinder;

        public TWeapon Weapon { get; set; }

        public int Level { get; set; }
        public abstract void Upgrade();
        // Start is called before the first frame update
        protected virtual void Start()
        {
            // TODO: Can this be required without the editor adding the script on the parent object?
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
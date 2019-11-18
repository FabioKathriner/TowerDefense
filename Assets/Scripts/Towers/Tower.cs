using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.Towers
{
    [RequireComponent(typeof(IWeapon))]
    [RequireComponent(typeof(Health.Health))]
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
            Weapon = GetComponentInChildren<TWeapon>();
            TargetFinder = GetComponentInChildren<TargetFinder>();
            if (TargetFinder != null)
                TargetFinder.TargetTags.AddRange(new[] {Tags.Enemy});
        }


        // Update is called once per frame
        protected virtual void Update()
        {
            _time += Time.deltaTime;

            if (_time >= RateOfFire)
            {
                _time = 0;
                Fire();
            }
        }

        protected virtual void Fire()
        {
            var nearestTarget = TargetFinder.GetNextTarget();
            if (nearestTarget != null)
                Weapon.Fire(nearestTarget);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Tower was hit!");
        }
    }
}
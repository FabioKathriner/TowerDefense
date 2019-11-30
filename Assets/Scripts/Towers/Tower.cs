using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.Towers
{
    public abstract class Tower : MonoBehaviour, IUpgradable
    {
        [SerializeField]
        private int _level = 1;

        [SerializeField]
        private int _upgradePrice = 50;

        [SerializeField]
        protected TextUpdater LevelText;

        [SerializeField]
        private int _healthUpgradeIncrement;

        protected int HealthUpgradeIncrement
        {
            get => _healthUpgradeIncrement;
            set => _healthUpgradeIncrement = value;
        }

        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                LevelText.UpdateText(_level.ToString());
            }
        }

        public int UpgradePrice
        {
            get => _upgradePrice;
            private set => _upgradePrice = value;
        }

        protected Health.Health Health;

        protected virtual void Start()
        {
            LevelText.UpdateText(_level.ToString());
            Health = GetComponent<Health.Health>();
        }

        public virtual void Upgrade()
        {
            Level++;
            UpgradePrice *= 2;
        }
    }

    [RequireComponent(typeof(Weapon))]
    [RequireComponent(typeof(Health.Health))]
    public abstract class Tower<TWeapon> : Tower
        where TWeapon : Weapon
    {
        private float _time;

        [SerializeField]
        protected float RateOfFire = 0.8f;

        protected TargetFinder TargetFinder;

        [SerializeField]
        private float _rateOfFireUpgradeIncrement;

        [SerializeField]
        private int _damageUpgradeIncrement;

        protected float RateOfFireUpgradeIncrement
        {
            get => _rateOfFireUpgradeIncrement;
            set => _rateOfFireUpgradeIncrement = value;
        }

        protected int DamageUpgradeIncrement
        {
            get => _damageUpgradeIncrement;
            set => _damageUpgradeIncrement = value;
        }

        public TWeapon Weapon { get; set; }


        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            // TODO: Can this be required without the editor adding the script on the parent object?
            Weapon = GetComponentInChildren<TWeapon>();
            TargetFinder = GetComponent<TargetFinder>();
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

        protected abstract void Fire();

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Tower was hit!");
        }
    }
}
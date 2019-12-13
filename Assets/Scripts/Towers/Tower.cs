using System;
using Assets.Scripts.Weapons;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Towers
{
    [RequireComponent(typeof(Health.Health))]
    public abstract class Tower : MonoBehaviour, IUpgradable
    {
        [SerializeField]
        private int _level = 1;

        [SerializeField]
        private int _maxLevel;

        [SerializeField]
        private int _buildPrice;

        [SerializeField]
        private int _upgradePrice = 50;

        [SerializeField]
        protected Text LevelText;

        [SerializeField]
        private int _healthUpgradeIncrement;

        private int _repairPrice;

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
                LevelText.text = _level.ToString();
            }
        }

        public int UpgradePrice
        {
            get => _upgradePrice;
            private set => _upgradePrice = value;
        }

        public int RepairPrice
        {
            get => _repairPrice;
            private set
            {
                _repairPrice = value;
                OnRepairPriceChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public int TotalValue { get; private set; }
        public int BuildPrice => _buildPrice;

        public int MaxLevel => _maxLevel;

        public event EventHandler OnRepairPriceChanged;

        public Health.Health Health;

        protected virtual void Start()
        {
            TotalValue = BuildPrice;
            LevelText.text = _level.ToString();
            Health = GetComponent<Health.Health>();
            Health.OnDamage += OnDamage;
        }

        public virtual void Upgrade()
        {
            Level++;
            TotalValue += UpgradePrice;
            UpgradePrice *= 2;
        }

        public void Repair()
        {
            Health.CurrentHealth = Health.MaxHealth;
            RepairPrice = 0;
        }

        private void OnDamage(object sender, EventArgs e)
        {
            RepairPrice = (int) (BuildPrice / (float)Health.MaxHealth * (Health.MaxHealth - Health.CurrentHealth) * 0.9);
        }
    }

    [RequireComponent(typeof(Weapon))]
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
using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.Towers
{
    [RequireComponent(typeof(Weapon))]
    [RequireComponent(typeof(Health.Health))]
    public abstract class Tower<TWeapon> : MonoBehaviour, IUpgradable
        where TWeapon : Weapon
    {
        private float _time;

        [SerializeField]
        protected TextUpdater LevelText;

        [SerializeField]
        protected float RateOfFire = 0.8f;

        protected TargetFinder TargetFinder;

        [SerializeField]
        private int _level = 1;

        [SerializeField]
        private float _rateOfFireUpgradeIncrement;
        [SerializeField]
        private int _healthUpgradeIncrement;
        [SerializeField]
        private int _damageUpgradeIncrement;

        protected float RateOfFireUpgradeIncrement
        {
            get => _rateOfFireUpgradeIncrement;
            set => _rateOfFireUpgradeIncrement = value;
        }

        protected int HealthUpgradeIncrement
        {
            get => _healthUpgradeIncrement;
            set => _healthUpgradeIncrement = value;
        }

        protected int DamageUpgradeIncrement
        {
            get => _damageUpgradeIncrement;
            set => _damageUpgradeIncrement = value;
        }

        protected Health.Health Health;

        public TWeapon Weapon { get; set; }

        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                LevelText.UpdateText(_level.ToString());
            }
        }

        public virtual void Upgrade()
        {
            Level++;
        }

        // Start is called before the first frame update
        protected virtual void Start()
        {
            LevelText.UpdateText(_level.ToString());
            Health = GetComponent<Health.Health>();
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

        protected abstract void Fire();

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Tower was hit!");
        }
    }
}
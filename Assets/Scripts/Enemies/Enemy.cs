using System;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private int _attackPower = 10;

        [SerializeField]
        private int _lootValue;

        private Health.Health _health;

        public PlayerStats PlayerStats { get; set; } // TODO: Can this property be safely removed?

        private void Awake()
        {
            _health = GetComponent<Health.Health>();
            _health.OnDie += OnDied;
        }

        private void OnDied(object sender, EventArgs e)
        {
            OnDie?.Invoke(this, e);
            _health.OnDie -= OnDied;
        }

        public int AttackPower
        {
            get => _attackPower;
            set => _attackPower = value;
        }

        public int LootValue => _lootValue;
        public event EventHandler<EventArgs> OnDie;
    }
}
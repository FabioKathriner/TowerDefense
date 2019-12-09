using System;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private int _attackPower = 10;

        [SerializeField]
        private int _lootValue;

        [SerializeField]
        private GameObject _deadBodyPrefab;

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
            if (_deadBodyPrefab != null)
            {
                var body = Instantiate(_deadBodyPrefab, transform.position, transform.rotation, transform.parent);
                var bodyRbs = body.GetComponentsInChildren<Rigidbody>();
                var navAgent = GetComponent<NavMeshAgent>();
                foreach (var bodyRb in bodyRbs)
                {
                    bodyRb.velocity = navAgent.velocity;
                }
                Destroy(body, 10f);
            }
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
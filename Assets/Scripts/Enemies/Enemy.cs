using System;
using Assets.Scripts.Towers;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemies
{
    [RequireComponent(typeof(Health.Health))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private int _attackPower = 10;

        [SerializeField]
        private int _lootValue;

        [SerializeField]
        private GameObject _deadBodyPrefab;

        private Health.Health _health;
        private float _timeSinceLastMeleeAttack;

        private void Awake()
        {
            _health = GetComponent<Health.Health>();
            _health.OnDie += OnDied;
        }

        private void OnCollisionStay(Collision collision)
        {
            _timeSinceLastMeleeAttack += Time.deltaTime;

            if (collision.gameObject.tag == Tags.Tower && _timeSinceLastMeleeAttack >= 0.5f)
            {
                _timeSinceLastMeleeAttack = 0;
                var tower = collision.gameObject.GetComponent<Tower>();
                tower.Health.TakeDamage(AttackPower);
            }
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
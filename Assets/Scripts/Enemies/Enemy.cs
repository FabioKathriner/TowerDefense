using System;
using Assets.Scripts.Towers;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemies
{
    [RequireComponent(typeof(Health.Health))]
    [RequireComponent(typeof(ParticleEffect))]
    public class Enemy : MonoBehaviour, IUnit
    {
        [SerializeField]
        private int _attackPower = 10;

        [SerializeField]
        private int _lootValue;

        [SerializeField]
        private GameObject _deadBodyPrefab;

        public Health.Health Health { get; private set; }

        private float _timeSinceLastMeleeAttack;


        private void Awake()
        {
            Health = GetComponent<Health.Health>();
            Health.OnDie += OnDied;
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
            Health.OnDie -= OnDied;
            if (_deadBodyPrefab != null)
            {
                var body = Instantiate(_deadBodyPrefab, transform.position, transform.rotation, transform.parent);
                var navAgent = GetComponent<NavMeshAgent>();
                var bodyRbs = body.GetComponentsInChildren<Rigidbody>();
                
                foreach (var bodyRb in bodyRbs)
                {
                    bodyRb.velocity = navAgent.velocity;
                }

                var bloodEffect = body.GetComponent<ParticleEffect>();
                bloodEffect.Explode();
                Destroy(body, 3f);
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
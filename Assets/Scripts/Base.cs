using System;
using System.Linq;
using Assets.Scripts.Enemies;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Health.Health))]
    public class Base : MonoBehaviour, IUnit
    {
        private bool _isEnemyClose;
        private AudioSource _deathSound;
        public Health.Health Health { get; private set; }
        public static Base Instance { get; private set; }

        private void Awake()
        {
            _deathSound = GetComponent<AudioSource>();
            Health = GetComponent<Health.Health>();
            Health.OnDie += OnBaseDestroyed;
            Health.OnDamage += (sender, args) => _deathSound.Play();

            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Debug.LogWarning($"There is more than one {nameof(Base)} in the current scene!");
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            var enemies = GameObject.FindGameObjectsWithTag(Tags.Enemy);
            if (enemies.Any(x => Vector3.Distance(x.transform.position, transform.position) < 50))
            {
                if (!_isEnemyClose)
                {
                    GameManager.Instance.MusicController.EnterCloseAction();
                    _isEnemyClose = true;
                }
            }
            else
            {
                GameManager.Instance.MusicController.ExitCloseAction();
                _isEnemyClose = false;
            }
        }

        // Collision only with Layers "Normal Enemy" and "Flying Enemy"
        void OnTriggerEnter(Collider other)
        {
            Debug.Log("Enemy reached the base");
            var enemy = other.GetComponentInParent<Enemy>();
            if (enemy != null)
            {
                Health.TakeDamage(enemy.AttackPower);
                var enemyHp = enemy.GetComponent<Health.Health>();
                enemyHp.Die();
            }
        }

        private void OnBaseDestroyed(object sender, EventArgs e)
        {
            GameManager.Instance.GameOver();
        }
    }
}

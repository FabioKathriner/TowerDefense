using System;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private int _attackPower = 10;

        protected virtual void Start()
        {
            var health = GetComponent<Health.Health>();
            health.OnDie += OnEnemyDied ;
        }

        private void OnEnemyDied(object sender, EventArgs args)
        {
            WaveSpawner.EnemyAliveCount--;
        }

        public int AttackPower
        {
            get => _attackPower;
            set => _attackPower = value;
        }
    }
}
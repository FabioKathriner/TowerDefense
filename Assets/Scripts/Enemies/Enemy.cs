﻿using System;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private int _attackPower = 10;
        public int LootValue;
        [SerializeField]
        private GameObject _gameManager;

        private PlayerStats _playerStats;

        protected virtual void Start()
        {
            var health = GetComponent<Health.Health>();
            _playerStats = _gameManager.GetComponent<PlayerStats>();
            health.OnDie += OnEnemyDied ;
        }

        private void OnEnemyDied(object sender, EventArgs args)
        {
            _playerStats.Money += LootValue;
            WaveSpawner.EnemyAliveCount--;
        }

        public int AttackPower
        {
            get => _attackPower;
            set => _attackPower = value;
        }
    }
}
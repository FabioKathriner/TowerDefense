using System;
using System.Collections;
using Assets.Scripts.Enemies;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class WaveSpawner : MonoBehaviour
    {
        private int _enemyAliveCount;
        private float _countdown = 2f;
        private int _waveIndex = 0;

        [SerializeField]
        private Wave[] _waves;

        [SerializeField]
        private Transform _spawnPoint;

        [SerializeField]
        private float _timeBetweenWaves = 5.5f;

        [SerializeField]
        private Text _waveCountDownText;

        private GameObject _enemiesParent;

        private void Start()
        {
            _enemiesParent = new GameObject("Enemies");
        }

        private void FixedUpdate()
        {
            if (_enemyAliveCount > 0)
                return;

            if (_countdown <= 0f)
            {
                StartCoroutine(SpawnWave());
                _countdown = _timeBetweenWaves;
                return;
            }
            _countdown -= Time.deltaTime;

            _countdown = Mathf.Clamp(_countdown, 0f, Mathf.Infinity);

            _waveCountDownText.text = $"{_countdown:00.00}";
        }

        private IEnumerator SpawnWave()
        {
            Wave wave = _waves[_waveIndex];
           
            for (int i = 0; i < wave.Count; i++)
            { 
                SpawnEnemy(wave.EnemyPrefab);
                yield return new WaitForSeconds(1f / wave.Rate);
            }

            _waveIndex++;
            Debug.Log("Wave Incoming!");

            if (_waveIndex == _waves.Length)
            {
                Debug.Log("Level Over!");
                this.enabled = false;
                GameManager.Instance.StageCleared();
            }
        }

        private void SpawnEnemy(GameObject enemyPrefab)
        {
            var instantiated = Instantiate(enemyPrefab, _spawnPoint.position, _spawnPoint.rotation, _enemiesParent.transform);
            var enemy = instantiated.GetComponent<Enemy>();
            enemy.OnDie += OnEnemyDied;
            _enemyAliveCount++;
        }

        private void OnEnemyDied(object sender, EventArgs args)
        {
            _enemyAliveCount--;
            var enemy = ((Enemy) sender);
            PlayerStats.Money += enemy.LootValue; // TODO: Simplify enemy death
            enemy.OnDie -= OnEnemyDied;
        }
    }
}

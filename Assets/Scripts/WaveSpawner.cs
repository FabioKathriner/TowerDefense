using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class WaveSpawner : MonoBehaviour
    {
        public static int EnemyAliveCount = 0;

        public Wave[] waves;

        //public Transform enemyPrefab;
        public Transform spawnPoint;

        public float timeBetweenWaves = 5.5f;
        private float countdown = 2f;

        public Text waveCountDownText;

        private int waveIndex = 0;

        void Update()
        {
            if (EnemyAliveCount > 0)
            {
                return;
            }

            if (countdown <= 0f)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
                return;
            }
            countdown -= Time.deltaTime;

            countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

            waveCountDownText.text = $"{countdown:00.00}";
        }

        IEnumerator SpawnWave()
        {
            Wave wave = waves[waveIndex];
           
            for (int i = 0; i < wave.Count; i++)
            { 
                SpawnEnemy(wave.Enemy);
                yield return new WaitForSeconds(1f / wave.Rate);
            }

            waveIndex++;
            Debug.Log("Wave Incoming!");

            if (waveIndex == waves.Length)
            {
                Debug.Log("Level Over!");
                this.enabled = false;
            }
        }

        void SpawnEnemy(GameObject Enemy)
        {
            Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation);
            EnemyAliveCount++;
        }
    }
}

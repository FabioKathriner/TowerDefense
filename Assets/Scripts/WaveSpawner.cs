using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class WaveSpawner : MonoBehaviour
    {
        public Transform enemyPrefab;
        public Transform spawnPoint;

        public float timeBetweenWaves = 5.5f;
        private float countdown = 2f;

        public Text waveCountDownText;

        private int waveIndex = 0;

        void Update()
        {
            if (countdown <= 0f)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
            }
            countdown -= Time.deltaTime;

            waveCountDownText.text = Mathf.Round(countdown).ToString();
        }

        IEnumerator SpawnWave()
        {

            waveIndex++;
            for (int i = 0; i < waveIndex; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }
        
            Debug.Log("Wave Incoming!");
        }

        void SpawnEnemy()
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}

using Assets.Scripts.UI_Elements;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(BuildManager))]
    [RequireComponent(typeof(PlayerStats))]
    [RequireComponent(typeof(WaveSpawner))]
    [RequireComponent(typeof(TowerSelector))]
    [RequireComponent(typeof(TimeManager))]
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public BuildManager BuildManager { get; private set; }
        public PlayerStats PlayerStats { get; private set; }
        public WaveSpawner WaveSpawner { get; private set; }
        public TowerSelector TowerSelector { get; private set; }
        public TimeManager TimeManager { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                BuildManager = GetComponent<BuildManager>();
                PlayerStats = GetComponent<PlayerStats>();
                WaveSpawner = GetComponent<WaveSpawner>();
                TowerSelector = GetComponent<TowerSelector>();
                TimeManager = GetComponent<TimeManager>();
            }
            else if (Instance != this)
            {
                Debug.LogWarning($"There was more than one {nameof(GameManager)} in the current scene!");
                Destroy(gameObject);
            }
        }
    }
}

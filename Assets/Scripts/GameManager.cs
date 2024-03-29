﻿using System;
using System.Collections;
using Assets.Scripts.UI_Elements.Unit;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    [RequireComponent(typeof(BuildManager))]
    [RequireComponent(typeof(PlayerStats))]
    [RequireComponent(typeof(WaveSpawner))]
    [RequireComponent(typeof(UnitSelector))]
    [RequireComponent(typeof(TimeManager))]
    [RequireComponent(typeof(MusicController))]
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public BuildManager BuildManager { get; private set; }
        public PlayerStats PlayerStats { get; private set; }
        public WaveSpawner WaveSpawner { get; private set; }
        public UnitSelector UnitSelector { get; private set; }
        public TimeManager TimeManager { get; private set; }
        public MusicController MusicController { get; private set; }

        public event EventHandler OnGameOver;
        public event EventHandler OnStageCleared;

        private void Awake()
        {
            Instance = this;
            BuildManager = GetComponent<BuildManager>();
            PlayerStats = GetComponent<PlayerStats>();
            WaveSpawner = GetComponent<WaveSpawner>();
            UnitSelector = GetComponent<UnitSelector>();
            TimeManager = GetComponent<TimeManager>();
            MusicController = GetComponent<MusicController>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
                StageCleared();
            if (Input.GetKey(KeyCode.M))
                PlayerStats.Money += 1;
        }

        public void GameOver()
        {
            OnGameOver?.Invoke(this, EventArgs.Empty);
            var towers = GameObject.FindGameObjectsWithTag(Tags.Tower);
            foreach (var tower in towers)
            {
                var hp = tower.GetComponent<Health.Health>();
                hp.Die();
            }
            TimeManager.Pause();
            Broadcast("GAME OVER");
        }

        public void StageCleared()
        {
            OnStageCleared?.Invoke(this, EventArgs.Empty);
            Broadcast("Stage cleared!");
            StartCoroutine(LoadNextLevel());
        }

        private IEnumerator LoadNextLevel()
        {
            yield return new WaitForSeconds(5f);

            var nextSceneBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextSceneBuildIndex >= SceneManager.sceneCountInBuildSettings)
            {
                Broadcast("Victory");
                StartCoroutine(Victory());
            }
            else
            {
                SceneManager.LoadScene(nextSceneBuildIndex);
            }
        }

        private static IEnumerator Victory()
        {
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("Main Menu");
        }

        public event EventHandler<MessageEventArgs> OnMessage;

        public void Broadcast(string message)
        {
            OnMessage?.Invoke(this, new MessageEventArgs(message));
        }
    }

    public class MessageEventArgs
    {
        public MessageEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}

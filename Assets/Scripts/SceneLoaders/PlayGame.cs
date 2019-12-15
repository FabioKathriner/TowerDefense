﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.SceneLoaders
{
    public class PlayGame : MonoBehaviour
    {
        public void Load()
        {
            SceneManager.LoadScene("Level Test 2");
        }
        public void OnQuit()
        {
            Application.Quit();
        }
    }
}
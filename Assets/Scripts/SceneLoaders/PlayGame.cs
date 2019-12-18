using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.SceneLoaders
{
    public class PlayGame : MonoBehaviour
    {
        public void Load()
        {
            SceneManager.LoadScene("Final Level 1");
        }

        public void OnQuit()
        {
            Application.Quit();
        }
    }
}

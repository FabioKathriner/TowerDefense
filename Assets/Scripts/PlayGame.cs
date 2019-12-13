using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class PlayGame : MonoBehaviour
    {
        public void Load()
        {
            SceneManager.LoadScene("Level Test 2");
        }
    }
}

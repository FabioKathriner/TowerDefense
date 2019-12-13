using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Logo : MonoBehaviour
    {

        public float timer = 30;
        // Start is called before the first frame update
        public void Load()
        {
            SceneManager.LoadScene("Play");
        }

        // Update is called once per frame
        void Update()
        {
            timer -= Time.deltaTime;

            if (timer <= 0) {
                SceneManager.LoadScene("Play");
            }
        }
    }
}

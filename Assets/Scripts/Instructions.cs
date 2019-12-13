using UnityEngine;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void LoadPlay()
    {
        SceneManager.LoadScene("Play");
    }
}

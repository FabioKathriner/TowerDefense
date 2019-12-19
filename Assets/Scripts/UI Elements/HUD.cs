using System;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameoverPanel;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnGameOver += OnGameOver;
    }

    private void OnGameOver(object sender, EventArgs e)
    {
        _gameoverPanel.SetActive(true);
    }

    public void OnRestartClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("Main Menu");
    }
}

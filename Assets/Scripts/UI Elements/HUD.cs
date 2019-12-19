using System;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameoverPanel;
    [SerializeField]
    private Text _moneyText;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnGameOver += OnGameOver;
        GameManager.Instance.PlayerStats.OnMoneyChanged += OnMoneyChanged;
    }

    private void OnMoneyChanged(object sender, EventArgs e)
    {
        _moneyText.text = GameManager.Instance.PlayerStats.Money.ToString();
    }

    private void OnGameOver(object sender, EventArgs e)
    {
        _gameoverPanel.SetActive(true);
    }

    public void OnRestartClick()
    {
        GameManager.Instance.TimeManager.Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("Main Menu");
    }
}

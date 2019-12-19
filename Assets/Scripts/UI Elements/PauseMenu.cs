using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI_Elements
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject _pauseMenuUi;
        private TimeManager _timeManager;

        private void Awake()
        {
            _timeManager = GameManager.Instance.TimeManager;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _timeManager.Pause();
                _pauseMenuUi.SetActive(true);
            }
        
        }

        public void OnSettingsClick()
        {
            _timeManager.Pause();
            _pauseMenuUi.SetActive(true);
        }
        public void OnContinueClick()
        {
            _timeManager.Resume();
            _pauseMenuUi.SetActive(false);
        }

        public void OnLoadMenuClick()
        {
            _timeManager.Resume();
            _pauseMenuUi.SetActive(false);
            SceneManager.LoadScene("Main Menu");
        }

        public void OnQuitGameClick()
        {
            Application.Quit();
        }
    }
}

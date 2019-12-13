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
                _timeManager.PauseResume();
                _pauseMenuUi.SetActive(_timeManager.GameSpeed == GameSpeed.Paused);
            }
        
        }

        public void OnSettingsClick()
        {
            _timeManager.PauseResume();
            _pauseMenuUi.SetActive(_timeManager.GameSpeed == GameSpeed.Paused);
        }

        public void OnLoadMenuClick()
        {
            _timeManager.PauseResume();
            SceneManager.LoadScene("Play");
        }

        public void OnQuitGameClick()
        {
            Application.Quit();
        }
    }
}

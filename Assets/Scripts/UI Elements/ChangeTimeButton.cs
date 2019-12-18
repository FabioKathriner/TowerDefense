using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI_Elements
{
    public class ChangeTimeButton : MonoBehaviour
    {
        [SerializeField]
        private Image _pauseResumeImage;
        [SerializeField]
        private Sprite _playImage;
        [SerializeField]
        private Sprite _pauseImage;

        private TimeManager _timeManager;

        private void Awake()
        {
            _timeManager = GameManager.Instance.TimeManager;
        }

        public void OnPauseResume()
        {
            _timeManager.PauseResume();
            _pauseResumeImage.sprite = _timeManager.GameSpeed == GameSpeed.Paused ? _playImage : _pauseImage;
        }

        public void OnGoFast()
        {
            _timeManager.GoFast();
            _pauseResumeImage.sprite = _pauseImage;
        }

        public void OnGoVeryFast()
        {
            _timeManager.GoVeryFast();
            _pauseResumeImage.sprite = _pauseImage;
        }

        public void OnGoSlow()
        {
            _timeManager.GoSlow();
            _pauseResumeImage.sprite = _pauseImage;
        }

        public void OnGoVerySlow()
        {
            _timeManager.GoVerySlow();
            _pauseResumeImage.sprite = _pauseImage;
        }
    }
}
using UnityEngine;

namespace Assets.Scripts.UI_Elements
{
    public class ChangeTimeButton : MonoBehaviour
    {
        private TimeManager _timeManager;

        private void Awake()
        {
            _timeManager = GameManager.Instance.TimeManager;
        }

        public void OnPauseResume()
        {
            _timeManager.PauseResume();
        }

        public void OnGoFast()
        {
            _timeManager.GoFast();
        }

        public void OnGoVeryFast()
        {
            _timeManager.GoVeryFast();
        }

        public void OnGoSlow()
        {
            _timeManager.GoSlow();
        }

        public void OnGoVerySlow()
        {
            _timeManager.GoVerySlow();
        }
    }
}
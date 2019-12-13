using UnityEngine;

namespace Assets.Scripts
{
    public class TimeManager : MonoBehaviour
    {
        private const float SpeedNormal = 1.0f;
        private const float SpeedPaused = 0f;
        private const float SpeedFast = 1.5f;
        private const float SpeedVeryFast = 2.0f;
        private const float SpeedSlow = 0.5f;
        private const float SpeedVerySlow = 0.25f;
        private float _fixedDeltaTime;
        private GameSpeed _gameSpeed;

        public GameSpeed GameSpeed => _gameSpeed;

        void Awake()
        {
            this._fixedDeltaTime = Time.fixedDeltaTime;
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                PauseResume();
            }
        }

        public void PauseResume()
        {
            if (GameSpeed == GameSpeed.Normal)
                Pause();
            else if (GameSpeed == GameSpeed.Paused)
                Resume();
            else
                Pause();
        }

        private void Resume()
        {
            Time.timeScale = SpeedNormal;
            Time.fixedDeltaTime = this._fixedDeltaTime * Time.timeScale;
            _gameSpeed = GameSpeed.Normal;
        }

        private void Pause()
        {
            Time.timeScale = SpeedPaused;
            Time.fixedDeltaTime = this._fixedDeltaTime * Time.timeScale;
            _gameSpeed = GameSpeed.Paused;

        }

        public void GoFast()
        {
            Time.timeScale = SpeedFast;
            Time.fixedDeltaTime = this._fixedDeltaTime * Time.timeScale;
            _gameSpeed = GameSpeed.Fast;
        }

        public void GoVeryFast()
        {

            Time.timeScale = SpeedVeryFast;
            Time.fixedDeltaTime = this._fixedDeltaTime * Time.timeScale;
            _gameSpeed = GameSpeed.VeryFast;
        }

        public void GoSlow()
        {

            Time.timeScale = SpeedSlow;
            Time.fixedDeltaTime = this._fixedDeltaTime * Time.timeScale;
            _gameSpeed = GameSpeed.Slow;
        }

        public void GoVerySlow()
        {

            Time.timeScale = SpeedVerySlow;
            Time.fixedDeltaTime = this._fixedDeltaTime * Time.timeScale;
            _gameSpeed = GameSpeed.VerySlow;
        }
    }

    public enum GameSpeed
    {
        Normal,
        Paused,
        Fast,
        VeryFast,
        Slow,
        VerySlow
    }
}
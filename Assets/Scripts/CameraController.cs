using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float panSpeed = 30f;

        [SerializeField] private float scrollSpeed = 5f;

        [Header("CameraLimits")] [SerializeField]
        private float minY = 10f;

        [SerializeField] private float maxY = 80f;
        [SerializeField] private float rotateSpeed = 10; // mouse down rotation speed about x and y axess

        private Vector3 _lastMousePosition;

        public void Start()
        {
            GameManager.Instance.OnGameOver += OnGameOver;
        }

        private void OnGameOver(object sender, EventArgs e)
        {
            var audioSources = GetComponentsInChildren<AudioSource>();
            foreach (var audioSource in audioSources)
            {
                audioSource.Stop();
            }
        }

        // Update is called once per frame
        void LateUpdate()
        {
            if (Input.GetKey("w") || (Input.GetKey("up")))
            {
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.Self);
            }

            if (Input.GetKey("s") || Input.GetKey("down"))
            {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.Self);
            }

            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.Self);
            }

            if (Input.GetKey("a") || Input.GetKey("left"))
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.Self);
            }

            if (Input.GetMouseButton(1))
            {
                // if the game window is separate from the editor window and the editor
                // window is active then you go to right-click on the game window the
                // rotation jumps if  we don't ignore the mouseDelta for that frame.
                Vector3 mouseDelta;
                if (_lastMousePosition.x >= 0 &&
                    _lastMousePosition.y >= 0 &&
                    _lastMousePosition.x <= Screen.width &&
                    _lastMousePosition.y <= Screen.height)
                    mouseDelta = Input.mousePosition - _lastMousePosition;
                else
                    mouseDelta = Vector3.zero;

                var rotation = Vector3.up * Time.deltaTime * rotateSpeed * mouseDelta.x;
                rotation.x = 0;
                rotation.z = 0;
                transform.Rotate(rotation, Space.Self);

                // Make sure z rotation stays locked
                rotation = transform.rotation.eulerAngles;
                transform.rotation = Quaternion.Euler(rotation);


                var cameraRotation = Vector3.left * Time.deltaTime * rotateSpeed * mouseDelta.y;
                cameraRotation.y = 0;
                cameraRotation.z = 0;
                Camera.main.transform.Rotate(cameraRotation, Space.Self);

                cameraRotation = Camera.main.transform.rotation.eulerAngles;
                Camera.main.transform.rotation = Quaternion.Euler(cameraRotation);
            }

            _lastMousePosition = Input.mousePosition;

            float scroll = Input.GetAxis("Mouse ScrollWheel");

            Vector3 pos = transform.position;
            pos.y -= scroll * 500 * scrollSpeed * Time.deltaTime;
            pos.y = Mathf.Clamp(pos.y, minY, maxY);

            transform.position = pos;
        }
    }
}

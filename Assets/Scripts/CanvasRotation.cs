using UnityEngine;

namespace Assets.Scripts
{
    public class CanvasRotation : MonoBehaviour
    {
        private void Update()
        {
            transform.rotation = Camera.main.transform.rotation;
        }
    }
}

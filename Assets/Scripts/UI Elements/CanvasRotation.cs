using UnityEngine;

namespace Assets.Scripts.UI_Elements
{
    public class CanvasRotation : MonoBehaviour
    {
        private void Update()
        {
            transform.rotation = Camera.main.transform.rotation;
        }
    }
}

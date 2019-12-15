using UnityEngine;

namespace Assets.Scripts.UI_Elements
{
    public class RangeDrawer : MonoBehaviour
    {
        [SerializeField]
        private int _radius = 10;

        [SerializeField]
        private Material _material;

        private const int LineSegments = 50;
        private void Start()
        {
            var lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.material = _material;
            lineRenderer.widthMultiplier = 0.2f;
            lineRenderer.useWorldSpace = false;
            lineRenderer.generateLightingData = true;
            lineRenderer.positionCount = LineSegments + 1;

            float x;
            float z;

            float angle = 20f;

            for (int i = 0; i < (LineSegments + 1); i++)
            {
                x = Mathf.Sin(Mathf.Deg2Rad * angle) * _radius;
                z = Mathf.Cos(Mathf.Deg2Rad * angle) * _radius;

                lineRenderer.SetPosition(i, new Vector3(x, 0.1f, z));

                angle += (360f / LineSegments);
            }
        }
    }
}

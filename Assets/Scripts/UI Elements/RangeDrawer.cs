using UnityEngine;

namespace Assets.Scripts.UI_Elements
{
    public class RangeDrawer : MonoBehaviour
    {
        [SerializeField]
        private int _radius;

        [SerializeField]
        private Material _material;

        [SerializeField]
        private bool _showInitially;

        [SerializeField]
        private GameObject _lineRendererObject;

        private LineRenderer _lineRenderer;

        private const int LineSegments = 50;

        public int Radius
        {
            get => _radius;
            set => _radius = value;
        }

        public Material Material
        {
            get => _material;
            set => _material = value;
        }

        public bool ShowInitially
        {
            get => _showInitially;
            set => _showInitially = value;
        }

        public GameObject LineRendererObject
        {
            get => _lineRendererObject;
            set => _lineRendererObject = value;
        }

        private void Start()
        {
            if (_lineRendererObject == null)
                _lineRendererObject = gameObject;

            _lineRenderer = LineRendererObject.GetComponent<LineRenderer>();
            if (_lineRenderer == null)
            {
                _lineRenderer = LineRendererObject.AddComponent<LineRenderer>();
                _lineRenderer.material = Material;
                _lineRenderer.widthMultiplier = 0.2f;
                _lineRenderer.useWorldSpace = false;
                _lineRenderer.generateLightingData = true;
                _lineRenderer.positionCount = LineSegments + 1;
                float x;
                float z;
                float angle = 20f;
                for (int i = 0; i < (LineSegments + 1); i++)
                {
                    x = Mathf.Sin(Mathf.Deg2Rad * angle) * Radius;
                    z = Mathf.Cos(Mathf.Deg2Rad * angle) * Radius;

                    _lineRenderer.SetPosition(i, new Vector3(x, 0.1f, z));

                    angle += (360f / LineSegments);
                }
            }

            _lineRenderer.enabled = ShowInitially;
        }

        public void Show()
        {
            _lineRenderer.enabled = true;
        }
        public void Hide()
        {
            _lineRenderer.enabled = false;
        }
    }
}

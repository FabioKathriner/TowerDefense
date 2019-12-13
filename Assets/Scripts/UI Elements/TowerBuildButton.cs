using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI_Elements
{
    public class TowerBuildButton : MonoBehaviour
    {
        [SerializeField]
        private GameObject _previewPrefab;

        [SerializeField]
        private GameObject _actualPrefab;

        private BuildManager _buildManager;

        private void Start()
        {
            _buildManager = BuildManager.Instance;
            var button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            _buildManager.EnterBuildMode(_previewPrefab, _actualPrefab);
        }
    }
}

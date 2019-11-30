using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class TowerBuildButton : MonoBehaviour
    {
        [SerializeField]
        private GameObject _previewPrefab;

        [SerializeField]
        private GameObject _actualPrefab;

        [SerializeField]
        private BuildManager _buildManager;

        private void Start()
        {
            var button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            _buildManager.EnterBuildMode(_previewPrefab, _actualPrefab);
        }
    }
}

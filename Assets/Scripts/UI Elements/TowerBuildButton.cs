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

        private void Start()
        {
            var button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            GameManager.Instance.BuildManager.EnterBuildMode(_previewPrefab, _actualPrefab);
        }
    }
}

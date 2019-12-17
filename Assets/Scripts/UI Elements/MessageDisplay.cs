using System.Collections;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class MessageDisplay : MonoBehaviour
{
    [SerializeField]
    private float _showForSeconds = 2f;
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void Start()
    {
        GameManager.Instance.OnMessage += (sender, args) => UpdateText(args.Message);
        gameObject.SetActive(false);
    }

    private void UpdateText(string message)
    {
        gameObject.SetActive(true);
        _text.text = message;
        StartCoroutine(HideMessage(_showForSeconds));
    }

    private IEnumerator HideMessage(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}

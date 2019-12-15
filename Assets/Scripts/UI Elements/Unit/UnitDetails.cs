using UnityEngine;
using UnityEngine.UI;

public class UnitDetails : MonoBehaviour
{
    [SerializeField]
    private Text _health;

    public string Health
    {
        set => _health.text = value;
    }
}

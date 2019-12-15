using UnityEngine;
using UnityEngine.UI;

public class TowerUnitDetails : MonoBehaviour
{
    [SerializeField]
    private Text _level;
    [SerializeField]
    private Text _health;
    [SerializeField]
    private Text _rateOfFire;
    [SerializeField]
    private Text _damage;

    public string Level
    {
        set => _level.text = value;
    }

    public string Health
    {
        set => _health.text = value;
    }

    public string RateOfFire
    {
        set => _rateOfFire.text = value;
    }

    public string Damage
    {
        set => _damage.text = value;
    }
}

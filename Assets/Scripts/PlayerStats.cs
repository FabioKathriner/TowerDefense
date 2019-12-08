using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private Text _moneyText;

    public int Money
    {
        get => _money;
        set
        {
            _money = value;
            _moneyText.text =_money.ToString();
        }
    }

    public int startMoney = 1000;

    private int _money;

    // Start is called before the first frame update
    void Start()
    {
        Money = startMoney;
    }
}

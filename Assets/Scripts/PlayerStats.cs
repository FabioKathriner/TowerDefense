using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private Text _moneyText;

    // Start is called before the first frame update
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

    void Start()
    {
        Money = startMoney;
    }
}

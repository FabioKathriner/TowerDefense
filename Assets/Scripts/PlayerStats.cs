using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private TextUpdater _moneyText;

    // Start is called before the first frame update
    public static int Money
    {
        get => _money;
        set
        {
            _money = value;
            _moneyText.UpdateText(_money.ToString());
        }
    }

    public int startMoney = 1000;
    private static int _money;

    void Start()
    {
        Money = startMoney;
    }
}

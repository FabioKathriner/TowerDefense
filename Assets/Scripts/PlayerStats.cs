using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public static int Money;
    public int startMoney = 1000;

    void Start()
    {
        Money = startMoney;
    }
}

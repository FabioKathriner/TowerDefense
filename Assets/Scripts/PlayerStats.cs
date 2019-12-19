using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PlayerStats : MonoBehaviour
    {
        public event EventHandler OnMoneyChanged;

        public int Money
        {
            get => _money;
            set
            {
                _money = value;
                OnMoneyChanged?.Invoke(typeof(PlayerStats), EventArgs.Empty);
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
}

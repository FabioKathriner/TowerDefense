using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField]
        private Text _moneyText;

        private static event EventHandler OnMoneyChanged;

        public static int Money
        {
            get => _money;
            set
            {
                _money = value;
                OnMoneyChanged?.Invoke(typeof(PlayerStats), EventArgs.Empty);
            }
        }

        public int startMoney = 1000;

        private static int _money;

        // Start is called before the first frame update
        void Start()
        {
            OnMoneyChanged += MoneyChanged;
            Money = startMoney;
        }

        private void MoneyChanged(object sender, EventArgs e)
        {
            _moneyText.text = $"{_money.ToString()}$";
        }
    }
}

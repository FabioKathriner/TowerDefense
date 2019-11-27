using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField]
        private int _attackPower = 10;

        public int AttackPower
        {
            get => _attackPower;
            set => _attackPower = value;
        }
    }
}
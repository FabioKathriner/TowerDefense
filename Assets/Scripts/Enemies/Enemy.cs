using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private int _attackPower = 10;

        private Health.Health _hp;

        public int AttackPower
        {
            get => _attackPower;
            set => _attackPower = value;
        }

        // Start is called before the first frame update
        private void Start()
        {
            _hp = GetComponent<Health.Health>();
        }

        public void Die()
        {
            _hp.Die();
        }
    }
}
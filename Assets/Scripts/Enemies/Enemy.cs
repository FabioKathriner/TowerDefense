using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public abstract class Enemy : MonoBehaviour
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
        protected virtual void Start()
        {
            _hp = GetComponent<Health.Health>();
        }

        public void Die()
        {
            _hp.Die();
        }
    }
}
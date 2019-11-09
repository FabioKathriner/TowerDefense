using UnityEngine;

namespace Assets.Scripts
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField]
        private int _maxHealth;

        [SerializeField]
        private int _currentHealth;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public int CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = value;
        }

        public int MaxHealth
        {
            get => _maxHealth;
            set => _maxHealth = value;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

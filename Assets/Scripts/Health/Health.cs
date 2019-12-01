using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Health
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField]
        private int _maxHealth;

        [SerializeField]
        private int _currentHealth;

        [SerializeField]
        private Image _healthBar;

        public event EventHandler<EventArgs> OnDie;
        public int CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = value;
                _healthBar.fillAmount = (float)_currentHealth / _maxHealth;
            }
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
                Die();
            }
        }

        public void Die()
        {
            OnDie?.Invoke(this, null);
            Destroy(gameObject);
        }
    }
}

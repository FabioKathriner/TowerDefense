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
            foreach (Transform child in transform)
            {
                // TODO: refactor
                if (child.gameObject.transform.childCount > 0)
                {
                    foreach (Transform child2 in child.transform)
                    {
                        child2.gameObject.AddComponent<BoxCollider>();
                        child2.gameObject.AddComponent<Rigidbody>();
                        child2.gameObject.layer = 0;
                        Destroy(child2.gameObject, 5f);
                    }
                    child.gameObject.transform.DetachChildren();
                }
                child.gameObject.AddComponent<BoxCollider>();
                child.gameObject.AddComponent<Rigidbody>();
                child.gameObject.layer = 0;
                Destroy(child.gameObject, 5f);
            }
            transform.DetachChildren();
            OnDie?.Invoke(this, null);
            Destroy(gameObject);
        }
    }
}

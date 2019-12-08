using System;
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

        public event EventHandler OnDie;
        public event EventHandler OnDamage;
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
                Die();
            else
                OnDamage?.Invoke(this, EventArgs.Empty);
        }

        public void Die()
        {
            //Uncomment Dismantle to make units explode into pieces on death
            //Dismantle();
            OnDie?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }

        private void Dismantle()
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.transform.childCount > 0)
                {
                    foreach (Transform child2 in child.transform)
                    {
                        child2.gameObject.AddComponent<BoxCollider>();
                        child2.gameObject.AddComponent<Rigidbody>();
                        child2.gameObject.layer = Layers.Default;
                        Destroy(child2.gameObject, 5f);
                    }

                    child.gameObject.transform.DetachChildren();
                }

                child.gameObject.AddComponent<BoxCollider>();
                child.gameObject.AddComponent<Rigidbody>();
                child.gameObject.layer = Layers.Default;
                Destroy(child.gameObject, 5f);
            }

            transform.DetachChildren();
        }
    }
}

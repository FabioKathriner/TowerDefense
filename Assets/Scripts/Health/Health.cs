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

        public event DeathHandler OnDie;
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
            _healthBar.fillAmount = (float)_currentHealth / _maxHealth;
            if (CurrentHealth <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            OnDie?.Invoke(this, null);
            StartCoroutine(ActivateTriggerExitAndDie());
        }

        // HACK: Moves the object far away so that the TargetFinder onTriggerExit triggers.
        // The Target will then be removed from the tracked objects list. Is there a better solution for this problem?
        private IEnumerator ActivateTriggerExitAndDie()
        {
            transform.Translate(Vector3.forward * 5000);
            yield return new WaitForSeconds(1f);
            
            Destroy(gameObject);
        }
    }

    public delegate void DeathHandler(object sender, EventArgs args);
}

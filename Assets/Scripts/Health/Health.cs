using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Health
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
                StartCoroutine(Die());
            }
        }

        // HACK: Moves the object far away so that the TargetFinder onTriggerExit triggers.
        // The Target will then be removed from the tracked objects list. Is there a better solution for this problem?
        private IEnumerator Die()
        {
            transform.Translate(Vector3.up * 5000);
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }
    }
}

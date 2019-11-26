using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class ElectroShocker : MonoBehaviour, IAoeWeapon
    {
        [SerializeField]
        protected int Damage = 10;

        public void Fire(GameObject target)
        {
            if (target == null)
                return;
            var health = target.GetComponentInParent<Health.Health>();
            if (health != null)
                health.TakeDamage(Damage);
        }

        public void Fire(List<GameObject> targets)
        {
            Debug.Log("Fire electroshocker");
            foreach (var target in targets)
            {
                Fire(target);
            }
        }
    }
}
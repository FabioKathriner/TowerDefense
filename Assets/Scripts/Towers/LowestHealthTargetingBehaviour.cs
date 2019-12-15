using System;
using UnityEngine;

namespace Assets.Scripts.Towers
{
    public class LowestHealthTargetingBehaviour : ITargetingBehaviour
    {
        public GameObject GetTarget(Collider[] hitColliders)
        {
            Tuple<GameObject, int> min = null;
            bool first = true;
            foreach (var hitCollider in hitColliders)
            {
                var targetHealth = hitCollider.gameObject.GetComponentInParent<Health.Health>().CurrentHealth;
                if (first)
                {
                    first = false;
                    min = new Tuple<GameObject, int>(hitCollider.gameObject, targetHealth);
                    continue;
                }


                if (!(min.Item2 < targetHealth))
                    min = new Tuple<GameObject, int>(hitCollider.gameObject, targetHealth);
            }

            return min?.Item1;
        }
    }
}
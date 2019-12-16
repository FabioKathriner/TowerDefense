using System;
using UnityEngine;

namespace Assets.Scripts.Towers
{
    public class MostHealthTargetingBehaviour : ITargetingBehaviour
    {
        public GameObject GetTarget(Collider[] hitColliders, LayerMask obstacleMask, Vector3 towerPosition)
        {
            Tuple<GameObject, int> max = null;
            bool first = true;
            foreach (var hitCollider in hitColliders)
            {
                if (Physics.Linecast(towerPosition, hitCollider.gameObject.transform.position, obstacleMask))
                    continue;

                var targetHealth = hitCollider.gameObject.GetComponentInParent<Health.Health>().CurrentHealth;
                if (first)
                {
                    first = false;
                    max = new Tuple<GameObject, int>(hitCollider.gameObject, targetHealth);
                    continue;
                }


                if (!(max.Item2 > targetHealth))
                    max = new Tuple<GameObject, int>(hitCollider.gameObject, targetHealth);
            }

            return max?.Item1;
        }
    }
}
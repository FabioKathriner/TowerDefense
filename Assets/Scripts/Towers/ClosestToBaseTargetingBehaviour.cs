using System;
using UnityEngine;

namespace Assets.Scripts.Towers
{
    public class ClosestToBaseTargetingBehaviour : ITargetingBehaviour
    {
        private readonly Vector3 _basePosition;

        public ClosestToBaseTargetingBehaviour()
        {
            _basePosition = Base.Instance.transform.position;
        }

        public GameObject GetTarget(Collider[] hitColliders, LayerMask obstacleMask, Vector3 towerPosition)
        {
            Tuple<GameObject, float> min = null;
            bool first = true;
            foreach (var hitCollider in hitColliders)
            {
                if (Physics.Linecast(towerPosition, hitCollider.gameObject.transform.position, obstacleMask))
                    continue;

                var distanceFromTargetToBase = Vector3.Distance(_basePosition, hitCollider.transform.position);
                if (first)
                {
                    first = false;
                    min = new Tuple<GameObject, float>(hitCollider.gameObject, distanceFromTargetToBase);
                    continue;
                }

                if (!(min.Item2 < distanceFromTargetToBase))
                    min = new Tuple<GameObject, float>(hitCollider.gameObject, distanceFromTargetToBase);
            }

            return min?.Item1;
        }
    }
}
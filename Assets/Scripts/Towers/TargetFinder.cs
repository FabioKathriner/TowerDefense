using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Towers
{
    public class TargetFinder : MonoBehaviour, ITargetFinder
    {
        [SerializeField]
        private int _radius;

        [SerializeField]
        private LayerMask _layerMask;

        public List<string> TargetTags { get; } = new List<string>();

        public GameObject GetNextTarget()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius, _layerMask);
            Target min = null;
            bool first = true;
            foreach (var hitCollider in hitColliders)
            {
                var targetDistance = Vector3.Distance(transform.position, hitCollider.transform.position);
                if (first)
                {
                    first = false;
                    min = new Target(hitCollider.gameObject, targetDistance);
                    continue;
                }


                if (!(min.Distance < targetDistance))
                    min = new Target(hitCollider.gameObject, targetDistance);
            }

            return min?.Enemy;
        }

        public List<GameObject> GetTargets()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius, _layerMask);
            return hitColliders.Select(x => x.gameObject).ToList();
        }
    }

    internal class Target
    {
        public Target(GameObject enemy, float distance)
        {
            Enemy = enemy;
            Distance = distance;
        }

        public GameObject Enemy { get; }
        public float Distance { get; set; }
    }
}
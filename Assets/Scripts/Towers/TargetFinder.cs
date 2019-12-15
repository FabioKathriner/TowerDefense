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

        public int Radius => _radius;
        public ITargetingBehaviour TargetingBehaviour { get; set; }

        private void Awake()
        {
            TargetingBehaviour = new ClosestToBaseTargetingBehaviour();
        }

        public GameObject GetNextTarget()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, Radius, _layerMask);
            return TargetingBehaviour.GetTarget(hitColliders);
        }

        public List<GameObject> GetTargets()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, Radius, _layerMask);
            return hitColliders.Select(x => x.gameObject).ToList();
        }
    }
}
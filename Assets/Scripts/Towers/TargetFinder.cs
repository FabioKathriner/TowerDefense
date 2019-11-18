using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Towers
{
    public class TargetFinder : MonoBehaviour, ITargetFinder
    {
        private readonly IList<Target> _targets = new List<Target>();
        public List<string> TargetTags { get; } = new List<string>();

        public GameObject GetNextTarget()
        {
            return _targets.OrderBy(x => x.Priority).Select(x => x.Enemy).FirstOrDefault();
        }

        public List<GameObject> GetTargets()
        {
            return _targets.Select(x => x.Enemy).ToList();
        }

        // Collision only with Layers defined on the Trigger
        private void OnTriggerEnter(Collider other)
        {
            if (TargetTags.Contains(other.attachedRigidbody.tag))
            {
                // TODO: Fix layer bug where enemy arrows trigger the range-trigger of the tank enemy
                Debug.Log($"{other.attachedRigidbody.name} entered range");
                _targets.Add(new Target(other.gameObject, _targets.Count + 1));
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (TargetTags.Contains(other.attachedRigidbody.tag))
            {
                Debug.Log($"{other.attachedRigidbody.name} left range");
                var collisionObjectId = other.gameObject.GetInstanceID();
                var target = _targets.First(x => x.Enemy.GetInstanceID() == collisionObjectId);
                _targets.Remove(target);
            }
        }
    }

    internal class Target
    {
        public Target(GameObject enemy, int priority)
        {
            Enemy = enemy;
            Priority = priority;
        }

        public GameObject Enemy { get; }
        public int Priority { get; set; }
    }
}
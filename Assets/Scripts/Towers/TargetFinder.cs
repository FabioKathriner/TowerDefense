using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Towers
{
    public class TargetFinder : MonoBehaviour, ITargetFinder
    {
        private readonly IList<Target> _targets = new List<Target>();

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        // Collision only with Layers "Normal Enemy" and "Flying Enemy"
        void OnTriggerEnter(Collider other)
        {
            Debug.Log("Object entered tower range");
            _targets.Add(new Target(other.gameObject, _targets.Count + 1));
        }

        void OnTriggerExit(Collider other)
        {
            Debug.Log("Object left tower range");
            var collisionObjectId = other.gameObject.GetInstanceID();
            var target = _targets.First(x => x.Enemy.GetInstanceID() == collisionObjectId);
            _targets.Remove(target);
        }

        public GameObject GetNextTarget()
        {
            return _targets.OrderBy(x => x.Priority).Select(x => x.Enemy).FirstOrDefault();
        }

        public List<GameObject> GetTargets()
        {
            return _targets.Select(x => x.Enemy).ToList();
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

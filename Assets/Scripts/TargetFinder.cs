using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class TargetFinder : MonoBehaviour
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
            _targets.Remove(_targets.First(x => x.Enemy.GetInstanceID() == collisionObjectId));
        }

        public GameObject GetNextTarget()
        {
            return _targets.OrderBy(x => x.Priority).Select(x => x.Enemy).FirstOrDefault();
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

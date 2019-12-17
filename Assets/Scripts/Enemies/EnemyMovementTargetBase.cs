using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMovementTargetBase : MonoBehaviour
    {
        
        private Transform _goal;        
        private NavMeshAgent _enemyAgent;

        
        void Start ()
        {
            _goal = GameObject.FindGameObjectWithTag("base").transform;
            _enemyAgent = GetComponent<NavMeshAgent>();
            _enemyAgent.enabled = true;
            _enemyAgent.autoBraking = false;
            _enemyAgent.destination = _goal.position;
        }
    }
}

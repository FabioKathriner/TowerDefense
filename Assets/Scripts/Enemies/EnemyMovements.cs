using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMovements : MonoBehaviour
    {
        private Transform _target;
        private int _waypointIndex = 0;
        private NavMeshAgent _enemyAgent;
    
        // Start is called before the first frame update
        private void Start()
        {
            var points = Waypoints.Points;
            if (points == null)
                return;

            _target = points[0];
            _enemyAgent = GetComponent<NavMeshAgent>();
            _enemyAgent.enabled = true;
            _enemyAgent.autoBraking = false;
            _enemyAgent.destination = _target.position;
        }

        private void FixedUpdate()
        {
            if (_enemyAgent != null && !_enemyAgent.pathPending && _enemyAgent.remainingDistance < 0.5f)
            {
                GetNextWaypoint();
            }

        }

        void GetNextWaypoint()
        {
            _waypointIndex++;

            if (_waypointIndex >= Waypoints.Points.Length)
            {
                Destroy(gameObject);
                return;
            }

            _enemyAgent.SetDestination(Waypoints.Points[_waypointIndex].position) ;
        
        }
    }
}
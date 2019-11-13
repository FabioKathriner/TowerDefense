using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovements : MonoBehaviour
{
    private Transform target;
    private int waypointIndex = 0;
    private NavMeshAgent enemyAgent;
    
    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.points[0];
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyAgent.autoBraking = false;
        enemyAgent.destination = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!enemyAgent.pathPending && enemyAgent.remainingDistance < 0.5f)
        {
            GetNextWaypoint();
        }

    }

    void GetNextWaypoint()
    {
        waypointIndex++;

        if (waypointIndex >= Waypoints.points.Length)
        {
            Destroy(gameObject);
            return;
        }

        enemyAgent.SetDestination(Waypoints.points[waypointIndex].position) ;
        
    }
}
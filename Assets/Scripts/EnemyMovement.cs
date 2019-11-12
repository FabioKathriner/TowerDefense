using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public Transform[] Waypoints;
    private int NextWaypoint = 0;
    private NavMeshAgent enemyAgent;
    //public static Transform[] WaypointsNew;

    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyAgent.autoBraking = false;

        GoToNextWaypoint();

    }

    

    void GoToNextWaypoint()
    {
       if (Waypoints.Length == 0)
            return;

       enemyAgent.destination = Waypoints[NextWaypoint].position;
        
       NextWaypoint = (NextWaypoint + 1);

       if (NextWaypoint == Waypoints.Length)
       {
           Destroy(gameObject);
       }



    }

    /*
    void GoToNextWaypointTest()
    {
        WaypointsNew = new Transform[transform.childCount];
        //Always get the next Waypoint.
        for (int i = 0; i < WaypointsNew.Length; i++)
        {
            WaypointsNew[i] = transform.GetChild(i);
        }
    }
    */

    void Update()
    {
        if(!enemyAgent.pathPending && enemyAgent.remainingDistance < 0.5f)
            GoToNextWaypoint();
    }
}

    

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsClass : MonoBehaviour
    //Work in Progress
{

    public static Transform[] Waypoints;


    void Awake()
    {
        Waypoints = new Transform[transform.childCount];
        //Always get the next Waypoint.
        for (int i = 0; i < Waypoints.Length; i++)
        {
            Waypoints[i] = transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;

namespace Assets.Scripts
{
    public class Waypoints : MonoBehaviour
    {
        // TODO: Do not use public static fields if possible
        public static Transform[] Points;


        void Awake()
        {
            Points = new Transform[transform.childCount];
            //Always get the next Waypoint.
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i] = transform.GetChild(i);
            }
        }
    }
}

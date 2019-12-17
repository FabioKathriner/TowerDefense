using UnityEngine;

namespace Assets.Scripts
{
    public class Waypoints : MonoBehaviour
    {
        public static Transform[] Points { get; private set; }
        
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

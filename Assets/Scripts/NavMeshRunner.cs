using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    public class NavMeshRunner : MonoBehaviour
    {

        public Transform goal;
       
        void Start () {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = goal.position; 
        }
    }
}

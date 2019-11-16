using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemies
{
    //Use the EnemeyMovements Script instead of this one.
    public class NavMeshRunner : MonoBehaviour
    {

        public Transform goal;
       
        void Start () {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = goal.position; 
        }
    }
}

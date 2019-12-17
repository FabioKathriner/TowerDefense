using Assets.Scripts;
using UnityEngine;

public class EnemyMovementsAlternative : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 10f;

    [SerializeField] 
    private Transform _target;

    private int _waypointIndex = 0;

    void Start()
    {
        _target = Waypoints.Points[0];
    }

    void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir),0.15f);
        transform.Translate(dir.normalized * _speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        _waypointIndex++;

        if (_waypointIndex >= Waypoints.Points.Length -1)
        {
            Destroy(gameObject);
            return;
        }
        _target = Waypoints.Points[_waypointIndex];
    }
}

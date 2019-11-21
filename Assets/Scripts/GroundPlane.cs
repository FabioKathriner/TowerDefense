using UnityEngine;
using UnityEngine.UIElements;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class GroundPlane : MonoBehaviour
{

    private GameObject turret;
    public LayerMask Mask;

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, Mask))
            Debug.DrawLine(ray.origin,hit.point);
        if (Input.GetMouseButtonDown(0))
        {

            GameObject _turretToBuild = BuildManager.instance.GetTurretToBuild();
            turret = (GameObject)Instantiate(_turretToBuild, hit.point, Quaternion.identity);
        }
    }
}

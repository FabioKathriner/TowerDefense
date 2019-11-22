using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UIElements;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class GroundPlane : MonoBehaviour
{

    private GameObject _turret;
    public LayerMask HitMask;
    public LayerMask IgnoreTowerMask;

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        RaycastHit nonhit;

        if (Physics.Raycast(ray, out hit, 1000, HitMask))
            Debug.DrawLine(ray.origin, hit.point);
        
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out nonhit, 1000, IgnoreTowerMask))
            {
                Debug.LogWarning("Can't place turret on top of another turret!'");
                return;
            }
            GameObject _turretToBuild = BuildManager.instance.GetTurretToBuild();
            _turret = (GameObject)Instantiate(_turretToBuild, hit.point, Quaternion.identity);
            Debug.LogWarning("Turret Placed successfully");
        }
    }
}

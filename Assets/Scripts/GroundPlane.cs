using UnityEngine;
using UnityEngine.EventSystems;
using Quaternion = UnityEngine.Quaternion;


public class GroundPlane : MonoBehaviour
{

    private GameObject _turret;
    public LayerMask HitMask;
    public LayerMask IgnoreTowerMask;

    private BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        RaycastHit nonhit;

        if (Physics.Raycast(ray, out hit, 1000, HitMask))
            Debug.DrawLine(ray.origin, hit.point);
        
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (buildManager.GetTurretToBuild() == null)
                return;

            if (Physics.Raycast(ray, out nonhit, 1000, IgnoreTowerMask))
            {
                Debug.LogWarning("Can't place turret on top of another turret!'");
                return;
            }

            GameObject _turretToBuild = buildManager.GetTurretToBuild();
            _turret = (GameObject)Instantiate(_turretToBuild, hit.point, Quaternion.identity);
            Debug.LogWarning("Turret Placed successfully");
        }
    }
}

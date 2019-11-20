using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class GroundPlane : MonoBehaviour
{

    private GameObject turret;
    public LayerMask Mask;
    //public LayerMask IgnoreLayer;
    //public Camera RayCastCamera;
    void OnMouseDown()
    {
        //Build a turret
        GameObject _turretToBuild = BuildManager.instance.GetTurretToBuild();
        
        Vector3 mousePos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,0f);
        Vector3 wordPos;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f, Mask))
        {
            wordPos = hit.point;
            Debug.LogWarning("Hitpoint found!");
        }
        else
        {
            wordPos = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.LogWarning("no hitpoint Found");
        }
        turret = (GameObject)Instantiate(_turretToBuild, wordPos, Quaternion.identity);
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
            Debug.DrawLine(ray.origin,hit.point);
    }
}

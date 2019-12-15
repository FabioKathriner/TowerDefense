using UnityEngine;

public interface IUnitDetailsProvider
{
    GameObject GetDetailsPrefab();
    string GetUnitName();
    void UpdateDetails(GameObject unitDetailsCanvas);
}
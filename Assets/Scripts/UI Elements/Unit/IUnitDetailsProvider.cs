using UnityEngine;

namespace Assets.Scripts.UI_Elements.Unit
{
    public interface IUnitDetailsProvider
    {
        GameObject GetDetailsPrefab();
        string GetUnitName();
        void UpdateDetails(GameObject unitDetailsCanvas);
    }
}
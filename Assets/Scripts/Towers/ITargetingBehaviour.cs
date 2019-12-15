using UnityEngine;

namespace Assets.Scripts.Towers
{
    public interface ITargetingBehaviour
    {
        GameObject GetTarget(Collider[] hitColliders);
    }
}
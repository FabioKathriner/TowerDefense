using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Towers
{
    public interface ITargetFinder
    {
        GameObject GetNextTarget();
        List<GameObject> GetTargets();
    }
}
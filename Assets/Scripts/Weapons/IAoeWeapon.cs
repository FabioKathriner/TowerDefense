using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public interface IAoeWeapon : IWeapon
    {
        void Fire(List<GameObject> targets);
    }
}
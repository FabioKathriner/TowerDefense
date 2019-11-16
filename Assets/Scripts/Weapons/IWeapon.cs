using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public interface IWeapon
    {
        void Fire(GameObject target);
    }
}
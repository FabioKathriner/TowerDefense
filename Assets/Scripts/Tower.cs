using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Tower : MonoBehaviour, IUpgradable
    {
        public IWeapon Weapon { get; set; }

        public int Level { get; set; }
        public abstract void Upgrade();
    }
}
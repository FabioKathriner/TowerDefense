using Assets.Scripts.Weapons.Projectiles;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Bow : MonoBehaviour, IWeapon
    {
        [SerializeField]
        private GameObject _projectilePrefab;

        [SerializeField]
        private Vector3 _spawnOffset = Vector3.forward * 0.5f;

        public void Fire(GameObject target)
        {
            transform.LookAt(target.transform);
            var projectile = Instantiate(_projectilePrefab, transform.position + _spawnOffset, transform.rotation);
            var arrow = projectile.GetComponent<Arrow>();
            if (arrow != null)
                arrow.Target = target;
        }
    }
}
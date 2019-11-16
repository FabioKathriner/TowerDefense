using Assets.Scripts.Weapons.Projectiles;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class RocketLauncher : MonoBehaviour, IWeapon
    {
        [SerializeField]
        private GameObject _projectilePrefab;

        [SerializeField]
        private float _forwardOffset = 0.5f;

        public void Fire(GameObject target)
        {
            transform.LookAt(target.transform);
            var projectile = Instantiate(_projectilePrefab, transform.position + Vector3.forward * _forwardOffset, transform.rotation);
            var script = projectile.GetComponent<Rocket>();
            if (script != null)
                script.Target = target;
        }
    }
}

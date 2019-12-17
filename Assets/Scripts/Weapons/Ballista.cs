using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Ballista : ProjectileWeapon
    {
        [SerializeField]
        private float _initialForce = 5f;

        public override void Fire(GameObject target)
        {
            var projectile = Instantiate(ProjectilePrefab, _spawnPointObject.transform.position, transform.rotation);
            projectile.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * _initialForce, ForceMode.Impulse);
        }
    }
}
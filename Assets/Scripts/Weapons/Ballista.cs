using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Ballista : ProjectileWeapon
    {

        [SerializeField]
        private Vector3 _spawnOffset = Vector3.up * 0.5f;

        [SerializeField]
        private float _initialForce = 5f;

        public override void Fire(GameObject target)
        {
            var projectile = Instantiate(ProjectilePrefab, transform.position + _spawnOffset, transform.rotation);
            projectile.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * _initialForce, ForceMode.Impulse);
        }
    }
}
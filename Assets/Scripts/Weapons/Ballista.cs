﻿using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Ballista : MonoBehaviour, ISimpleWeapon
    {
        [SerializeField]
        private GameObject _projectilePrefab;

        [SerializeField]
        private Vector3 _spawnOffset = Vector3.up * 0.5f;

        [SerializeField]
        private float _initialForce = 5f;

        public void Fire()
        {
            var projectile = Instantiate(_projectilePrefab, transform.position + _spawnOffset, transform.rotation);
            projectile.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * _initialForce, ForceMode.Impulse);
        }

        public void Fire(GameObject target)
        {
            // not used
            throw new System.NotImplementedException();
        }
    }
}
﻿using UnityEngine;

namespace Assets.Scripts
{
    public class Base : MonoBehaviour, IHealth, IDamagable
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }
    }
}

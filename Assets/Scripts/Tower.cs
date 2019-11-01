using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour, IHealth, IDamagable, IUpgradable
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
    public IFireBehavior FireBehavior { get; set; }

    public void Fire()
    {
        FireBehavior.Fire();
    }

    public int Level { get; set; }
    public void Upgrade()
    {
        throw new System.NotImplementedException();
    }
}
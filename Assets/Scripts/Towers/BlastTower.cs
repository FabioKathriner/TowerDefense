using System;
using System.Linq;
using Assets.Scripts.Towers;
using Assets.Scripts.Weapons;
using UnityEngine;

[RequireComponent(typeof(ElectroShocker))]
public class BlastTower : Tower<IAoeWeapon>
{
    public override void Upgrade()
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Weapon = GetComponent<ElectroShocker>();
    }

    protected override void Fire()
    {
        var targets = TargetFinder.GetTargets();
        if (targets != null && targets.Any())
            Weapon.Fire(targets);
    }
}
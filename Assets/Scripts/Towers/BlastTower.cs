using System;
using System.Linq;
using Assets.Scripts.Towers;
using Assets.Scripts.Weapons;
using UnityEngine;

[RequireComponent(typeof(ElectroShocker))]
public class BlastTower : Tower<ElectroShocker>
{
    public override void Upgrade()
    {
        throw new NotImplementedException();
    }

    protected override void Fire()
    {
        var targets = TargetFinder.GetTargets();
        if (targets != null && targets.Any())
            Weapon.Fire(targets);
    }
}
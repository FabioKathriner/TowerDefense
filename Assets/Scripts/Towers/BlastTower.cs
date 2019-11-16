using System.Linq;
using UnityEngine;
using Assets.Scripts.Towers;
using Assets.Scripts.Weapons;

[RequireComponent(typeof(ElectroShocker))]
public class BlastTower : Tower<IAoeWeapon>
{
    private float _time;

    // Use this for initialization
    public override void Upgrade()
    {
        throw new System.NotImplementedException();
    }

    protected override void Start()
    {
        base.Start();
        Weapon = GetComponent<ElectroShocker>();
    }

    protected override void Update()
    {
        // TODO: Refactor Towers, add aiming behavior
        _time += Time.deltaTime;

        if (_time >= RateOfFire)
        {
            _time = 0;
            var targets = TargetFinder.GetTargets();
            if (targets != null && targets.Any())
                Weapon.Fire(targets);
        }
    }
}

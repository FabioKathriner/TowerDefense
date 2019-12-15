using Assets.Scripts.Health;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class UnitDetailsProvider : MonoBehaviour, IUnitDetailsProvider
{
    [SerializeField]
    private GameObject _detailsPrefab;
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public GameObject GetDetailsPrefab()
    {
        UpdateDetails(_detailsPrefab);
        return _detailsPrefab;
    }

    public string GetUnitName()
    {
        return gameObject.name;
    }

    public void UpdateDetails(GameObject unitDetailsCanvas)
    {
        var unitDetails = unitDetailsCanvas.GetComponent<UnitDetails>();
        unitDetails.Health = $"Health: {_health.CurrentHealth} / {_health.MaxHealth}";
    }
}
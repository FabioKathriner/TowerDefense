using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
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

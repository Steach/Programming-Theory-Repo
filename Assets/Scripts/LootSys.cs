using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSys : Inventory
{
    void Start()
    {
        
    }
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("AmmoBox"))
        {
            DebugMethod();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSys : Inventory
{
    void Start()
    {
        Debug.Log("Start LootSys: " + assaultBullets);
    }
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("AmmoBox"))
        {
            //DebugMethod();
            Inventory.Instance.AssaultBullets += 120;
            Debug.Log("LootSys: " + assaultBullets);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSys : Inventory
{
    void Start()
    {
        //Debug.Log("Start LootSys: " + assaultBullets);
    }
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("AmmoBox"))
        {
            DebugMethod();
            //Debug.Log("LootSys: " + assaultBullets);
        }
    }
}

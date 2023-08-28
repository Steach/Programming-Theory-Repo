using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSys : MonoBehaviour
{
    private Inventory inventory;
    void Start()
    {
        inventory = GameObject.Find("InventorySystem").GetComponent<Inventory>();
    }
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("AmmoBox"))
        {
            inventory.DebugMethod();
        }
    }
}

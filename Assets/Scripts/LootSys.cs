using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSys : MonoBehaviour
{
    private Inventory inventory;

    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("AmmoBox"))
        {
            Destroy(other.gameObject);
            inventory.DebugMethod();
        }
    }
}

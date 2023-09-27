using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConusCollisionDetect : MonoBehaviour
{

    private bool playerInTarget;
    // Start is called before the first frame update
    void Start()
    {
        playerInTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerInTarget = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerInTarget = false;
        }
    }

    public bool TakeTheTarget()
    {
        return playerInTarget;
    }
}

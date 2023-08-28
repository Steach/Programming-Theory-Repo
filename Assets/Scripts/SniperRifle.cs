using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifle : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        //clipCapacity = 5;
        shotsPerMin = 1;
        reloadTime = 2;
        kickbacklForce = 10;
        damagePoint = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

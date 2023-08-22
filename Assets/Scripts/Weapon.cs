using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Inventory
{
    protected int clipCapacity;
    protected int shotsPerMin;
    protected float reloadTime;
    protected float kickbacklForce;
    protected float damagePoint;
    protected float bulletSpeed;
    protected int oneMin = 60;

    virtual protected void Shoot(GameObject bulPrefab, Transform firePos)
    {
        GameObject bulletInstance = Instantiate(bulPrefab, firePos.position, firePos.rotation) as GameObject;
    }
}

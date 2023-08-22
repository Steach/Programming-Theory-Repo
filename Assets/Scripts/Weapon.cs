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
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform firePosition;
    

    virtual protected void Shoot(GameObject bulPrefab, Transform firePos)
    {
        GameObject bulletInstance = Instantiate(bulPrefab, firePos.position, firePos.rotation) as GameObject;
    }

    virtual protected int Reload(int currentClipCapacity, int clipCap, int weaponID)
    {
        int ammoCapacity = clipCap - currentClipCapacity;
        int bullets = BulletsStuff(weaponID);
        Debug.Log("Bullets: " + bullets);

        if (bullets > ammoCapacity)
        {
            currentClipCapacity += ammoCapacity;
            BulletsStuff(weaponID, ammoCapacity);
            ammoCapacity = 0;
            return currentClipCapacity;
        }
        else if (bullets <= ammoCapacity)
        {
            currentClipCapacity += bullets;
            BulletsStuff(weaponID, ammoCapacity);
            ammoCapacity = 0;
            return currentClipCapacity;
        }
        else
        {
            return 0;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Weapon : MonoBehaviour
{
    //protected int clipCapacity;
    protected int shotsPerMin;
    protected float reloadTime;
    protected float kickbacklForce;
    protected float damagePoint;
    protected float bulletSpeed;
    protected int oneMin = 60;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform firePosition;
    [SerializeField] protected TextMeshProUGUI reloadingText;
    [SerializeField] protected ParticleSystem shootExplosion;
    [SerializeField] protected TextMeshProUGUI bulletText;
    protected int bullets;
    protected Inventory inventory;

    virtual protected void Shoot(GameObject bulPrefab, Transform firePos, ParticleSystem shootPrticle)
    {
        GameObject bulletInstance = Instantiate(bulPrefab, firePos.position, firePos.rotation) as GameObject;
        shootPrticle.Play();
    }

    virtual protected int Reload(int currentClipCapacity, int clipCap, int weaponID)
    {
        int ammoCapacity = clipCap - currentClipCapacity;
        bullets = inventory.BulletsStuff(weaponID);
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (bullets > ammoCapacity)
            {
                currentClipCapacity += ammoCapacity;
                inventory.BulletsStuff(weaponID, ammoCapacity);
                ammoCapacity = 0;
            }
            else if (bullets <= ammoCapacity)
            {
                currentClipCapacity += bullets;
                inventory.BulletsStuff(weaponID, bullets);
                ammoCapacity = 0;
            }
        }
        return currentClipCapacity;
    }

    virtual protected void RealodingText(int currentClipCapacity)
    {
        if (currentClipCapacity > 0)
        {
            reloadingText.text = "";      
        }
        else
        {
            reloadingText.text = "No ammo. Need to reload.";
        }
    }

    virtual protected void AmmoText(int currentClipCapacity)
    {
        bulletText.text = "Bullets: " + currentClipCapacity + "/" + bullets;
    }
}

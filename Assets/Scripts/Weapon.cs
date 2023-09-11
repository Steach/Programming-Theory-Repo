using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Weapon : MonoBehaviour
{
    protected int clipCapacity;
    protected int shotsPerMin;
    protected float reloadTime;
    protected float kickbacklForce;
    protected float damagePoint;
    protected float bulletSpeed;
    protected float recoilForce;
    protected int oneMin = 60;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform firePosition;
    [SerializeField] protected TextMeshProUGUI reloadingText;
    [SerializeField] protected ParticleSystem shootExplosion;
    [SerializeField] protected TextMeshProUGUI bulletText;
    protected Recoil recoil;
    private int bullets;
    private Inventory inventory;
    
    void Awake()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
    void Update()
    {
        
    }

    virtual protected void Shoot(GameObject bulPrefab, Transform firePos, ParticleSystem shootPrticle, float recoilF)
    {
        recoil = GameObject.Find("Head").GetComponent<Recoil>();
        recoil.Recoiling(recoilF);
        GameObject bulletInstance = Instantiate(bulPrefab, firePos.position, firePos.rotation) as GameObject;
        shootPrticle.Play();
    }

    virtual protected int Reload(int currentClipCapacity, int clipCap, int weaponID)
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            int ammoCapacity = clipCap - currentClipCapacity;
            bullets = inventory.BulletsStuff(weaponID);

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

    virtual protected string RealodingText(int currentClipCapacity)
    {
        if (currentClipCapacity > 0)
        {
            return "";      
        }
        else
        {
            return "No ammo. Need to reload.";
        }
    }

    virtual protected string AmmoText(int currentClipCapacity, int weaponID)
    {
        string bulletsStr = "Bullets: " + currentClipCapacity + "/" + inventory.BulletsStuff(weaponID);
        return bulletsStr;
    }

}

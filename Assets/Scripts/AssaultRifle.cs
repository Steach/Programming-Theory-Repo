using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Weapon
{
    private Vector3 offsetForePos;
    private float fireTimeout;
    private float fireRatePS = 11.6f;
    private int weaponIndex = 0;
    private int currentClipCapacity;
    // Start is called before the first frame update
    void Start()
    {
        fireTimeout = 0;
        clipCapacity = 20;
        shotsPerMin = 1;
        reloadTime = 2;
        kickbacklForce = 3;
        damagePoint = 7;
        bulletSpeed = 10;
        assaultBullets = assaultBullets - clipCapacity;
        bulletText.text = "Bullets: " + clipCapacity + "/" + assaultBullets;
        currentClipCapacity = clipCapacity;        
    }

    // Update is called once per frame
    void Update()
    {
        bulletText.text = "Bullets: " + currentClipCapacity + "/" + assaultBullets;
        fireTimeout += Time.deltaTime;
        if (fireTimeout >= (1f / fireRatePS) && currentClipCapacity > 0 && Input.GetKey(KeyCode.Mouse0))
        {
            Shoot(bulletPrefab, firePosition);
            currentClipCapacity -= 1;
            fireTimeout = 0f;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            currentClipCapacity = Reload(currentClipCapacity, clipCapacity, weaponIndex);
        }
    }
}
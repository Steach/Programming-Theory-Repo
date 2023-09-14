using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Weapon
{
    private Vector3 offsetForePos;
    private float fireTimeout;
    private float fireRatePS = 11.6f;
    protected int weaponIndex = 0;
    private int currentClipCapacity;
    // Start is called before the first frame update
    void Start()
    {
        aiming = false;
        fireTimeout = 0;
        clipCapacity = 20;
        shotsPerMin = 1;
        reloadTime = 2;
        kickbacklForce = 3;
        damagePoint = 7;
        recoilForce = 0.5f;
        RealodingText(currentClipCapacity);
        currentClipCapacity = clipCapacity;
        shootExplosion.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        AimPos();
        reloadingText.text = RealodingText(currentClipCapacity);
        bulletText.text = AmmoText(currentClipCapacity, weaponIndex);
        fireTimeout += Time.deltaTime;
        AssaultShoot();
        currentClipCapacity = Reload(currentClipCapacity, clipCapacity, weaponIndex);
    }

    private void AssaultShoot()
    {
        if (fireTimeout >= (1f / fireRatePS) && currentClipCapacity > 0 && Input.GetKey(KeyCode.Mouse0))
        {
            Shoot(bulletPrefab, firePosition, shootExplosion, recoilForce);
            currentClipCapacity -= 1;
            fireTimeout = 0f;
        }
        else
        {
            shootExplosion.Stop();
        }
    }

    public int GetWeapIndex()
    {
        return weaponIndex;
    }

    private void AimPos()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            AimPosition(gameObject);
            aiming = true;
        }
        else
        {
            gameObject.transform.position = defaultPosition.position;
            aiming = false;
        }
    }
}
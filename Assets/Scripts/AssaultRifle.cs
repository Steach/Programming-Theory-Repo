using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Weapon
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] private Transform firePosition;
    private Vector3 offsetForePos;
    private float fireTimeout;
    private float fireRatePS = 11.6f;
    // Start is called before the first frame update
    void Start()
    {
        fireTimeout = 0;
        clipCapacity = 30;
        shotsPerMin = 1;
        reloadTime = 2;
        kickbacklForce = 3;
        damagePoint = 7;
        bulletSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        fireTimeout += Time.deltaTime;
        if (fireTimeout >= 1f / fireRatePS)
        {
            Shoot(bulletPrefab, firePosition);
            fireTimeout = 0f;
        }
    }
}

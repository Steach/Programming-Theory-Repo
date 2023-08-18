using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Weapon
{
    [SerializeField] GameObject bulletPrefab;
    private Vector3 starPosition;
    [SerializeField] private Transform firePosition;
    private Vector3 offsetForePos;
    // Start is called before the first frame update
    void Start()
    {
        clipCapacity = 30;
        shotsPerMin = 1;
        reloadTime = 2;
        kickbacklForce = 3;
        damagePoint = 7;
        bulletSpeed = 10;
        offsetForePos = new Vector3 (0, -0.136f, 1.079f);
    }

    // Update is called once per frame
    void Update()
    {
        float fire = Input.GetAxis("Fire1");
        if (fire > 0)
        {
            Shoot();
        }
    }

    override protected void Shoot()
    {
        GameObject bulletInstance = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation) as GameObject;
        //bulletInstance.transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }
}

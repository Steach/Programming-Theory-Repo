using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Weapon
{
    [SerializeField] GameObject bulletPrefab;
    private Vector3 starPosition;
    Transform firePosition;
    // Start is called before the first frame update
    void Start()
    {
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
        float fire = Input.GetAxis("Fire1");
        if (fire > 0)
        {
            Shoot();
        }
    }

    override protected void Shoot()
    {
        firePosition = transform;
        GameObject bulletInstance = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation) as GameObject;
        //bulletInstance.transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }
}

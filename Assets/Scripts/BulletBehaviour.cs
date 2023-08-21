using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : AssaultRifle
{
    private float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 0;
        bulletSpeed = 200;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        transform.Translate(Vector3.left * bulletSpeed * Time.deltaTime);
        BulletDeath();
    }

    void BulletDeath()
    {
        if(lifeTime >= 3)
        {
            Destroy(gameObject);
        }
    }
}

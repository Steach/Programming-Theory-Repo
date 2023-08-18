using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : AssaultRifle
{
    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = 200;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * bulletSpeed * Time.deltaTime);
    }
}

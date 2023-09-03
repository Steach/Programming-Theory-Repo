using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : AssaultRifle
{
    private float lifeTime;
    private Rigidbody bulletrb;
    private Vector3 currentPosition;
    private Vector3 previuslyPosition;
    private GameObject target = null;
    // Start is called before the first frame update
    void Start()
    {
        previuslyPosition = transform.position;
        lifeTime = 0;
        bulletSpeed = 25f;
        bulletrb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        VarificationShoot();
        BulletDeath();
    }

    void BulletDeath()
    {
        if(lifeTime >= 7)
        {
            Destroy(gameObject);
        }
    }


    void VarificationShoot()
    {
        currentPosition = transform.position;

        Vector3 bulletDirection = -transform.right;
        Vector3 direction = currentPosition - previuslyPosition;
        float distence = direction.magnitude;
        bulletrb.AddForce(bulletDirection * bulletSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
        lifeTime += Time.deltaTime;

        Debug.DrawLine(currentPosition, previuslyPosition, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(currentPosition, direction, out hit, distence))
        {
            if (hit.collider.CompareTag("TargetBody"))
            {
                Debug.Log("Bullet hit the target");
                Destroy(gameObject);
            }
            
            
        }
        
        previuslyPosition = currentPosition;
    }
}

/*
draft

if (target == null)
{
    target = hit.collider.gameObject;
}
else if (target != null)
{
    Debug.Log("Bullet hit the target!");
    Destroy(gameObject);
}

//transform.Translate(Vector3.left * bulletSpeed * Time.deltaTime);
//Debug.DrawLine(transform.position, (transform.position + bulletDirection) * 100, Color.red);

*/
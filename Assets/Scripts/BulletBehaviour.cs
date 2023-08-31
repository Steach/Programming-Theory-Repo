using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : AssaultRifle
{
    private float lifeTime;
    private Rigidbody bulletrb;
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 0;
        bulletSpeed = 0.1f;
        bulletrb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 bulletDirection = -transform.right;
        lifeTime += Time.deltaTime;
        //transform.Translate(Vector3.left * bulletSpeed * Time.deltaTime);
        bulletrb.AddForce(bulletDirection * bulletSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
        Debug.DrawLine(transform.position, (transform.position + bulletDirection) * 100, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, bulletDirection, out hit, 1000))
        {
            if (hit.collider != null & hit.collider.CompareTag("TargetBody"))
            {
                // Обробка попадання в ціль
                Debug.Log("Bullet hit the target!");
                Destroy(gameObject);
            }
        }

        //BulletDeath();
    }

    void BulletDeath()
    {
        if(lifeTime >= 3)
        {
            Destroy(gameObject);
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TargetHead"))
        {
            Debug.Log("HeadShot");
            Destroy(gameObject);
        }

        if(other.CompareTag("TargetBody"))
        {
            Debug.Log("BodyShot");
            Destroy(gameObject);
        }
    }*/

    /*private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("TargetHead"))
        {
            Debug.Log("HeadShot");
            Destroy(gameObject);
        }

        if(other.gameObject.CompareTag("TargetBody"))
        {
            Debug.Log("BodyShot");
            Destroy(gameObject);
        }
    }*/
}

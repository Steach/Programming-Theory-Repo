using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private float lifeTime;
    private Rigidbody bulletrb;
    private Vector3 currentPosition;
    private Vector3 previuslyPosition;
    //private GameObject target = null;
    private float damage;
    private Enemy enemy;
    private int enemiesCount;
    private float bulletSpeed;
    private int weaponIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        FindEnemies();
        FindWeapon();
        previuslyPosition = transform.position;
        lifeTime = 0;
        bulletSpeed = 25f;
        bulletrb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        FindEnemies();
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
            if (enemiesCount > 0 && hit.collider.CompareTag("TargetBody"))
            {
                Debug.Log("Bullet hit the target: " + damage);
                enemy.ShootEnemy(damage);
                Destroy(gameObject);
            }
        }
        
        previuslyPosition = currentPosition;
    }

    void DamagePoint(int index)
    {
        EBulletsNum weaponIndx = (EBulletsNum) index;
        
        switch(weaponIndx)
        {
            case EBulletsNum.assault:
            {
                damage = 29;
            }
            break;

            case EBulletsNum.sniper:
            {
                damage = 101;
            }
            break;

            case EBulletsNum.handgun:
            {
                damage = 21;
            }
            break;

            default: damage = 0; break;
        }
        
    }

    private void FindEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("TargetBody");
        enemiesCount = enemies.Length;
        if (enemiesCount > 0)
        {  
            enemy = GameObject.Find("Target(Clone)").GetComponent<Enemy>();
        }
    }

    private void FindWeapon()
    {
        GameObject[] weapons = GameObject.FindGameObjectsWithTag("Weapon");
        int weaponCount = weapons.Length;
        if (weaponCount > 0)
        {
            AssaultRifle assaultRifleScript = weapons[0].GetComponent<AssaultRifle>();
            if (assaultRifleScript != null)
            {
                weaponIndex = 0;
                DamagePoint(weaponIndex);
            }

            SniperRifle SniperRifleScript = weapons[0].GetComponent<SniperRifle>();
            if (SniperRifleScript != null)
            {
                weaponIndex = 1;
                DamagePoint(weaponIndex);
            }

            HandGun handGunScript = weapons[0].GetComponent<HandGun>();
            if (handGunScript != null)
            {
                weaponIndex = 2;
                DamagePoint(weaponIndex);
            }
        }
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
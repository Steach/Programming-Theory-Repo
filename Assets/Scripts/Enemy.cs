using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private GameObject loot;
    private Rigidbody enemyRB;
    private Vector3 currentPosition;
    private float health = 100;
    private bool playerInTarget = false;
    private bool playerCollision = false;
    private bool dead = false;
    private bool fall = false;
    private bool aggressive = false;
    private float speed = 10;
    private float maxDistance = 5;
    private float timer;
    private float moanTime = 5.0f;
    private float minDistanceToPlayer = 1.7f;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Quaternion startRotation;
    private Quaternion endRotation;
    private float rotationSpeed = 1;
    private float _t;
    [SerializeField] private ConusCollisionDetect conusCollisionDetect;
    private FieldOfVision fieldOfVision;
    private int _id;
    
    [Header("Sound")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] zombieMoans;
    [SerializeField] private AudioClip zombieHit;
    [SerializeField] private AudioClip zombieAgressive;
    [SerializeField] private AudioClip zombieFall;
    // Start is called before the first frame update
    void Start()
    {
        fieldOfVision = GetComponent<FieldOfVision>();
        healthSlider.maxValue = health;
        healthSlider.value = health;
        Debug.Log("Health: " + health);
        startPosition = transform.position;
        startRotation = transform.rotation;
        endRotation = Quaternion.Euler(0, 180, 0);
        enemyRB = gameObject.GetComponent<Rigidbody>();
        Debug.Log(_id);
    }

    // Update is called once per frame
    void Update()
    {
        GetTarget();
        currentPosition = transform.position;
        if (health <= 0)
        {
            dead = true;
            StartCoroutine(DeathTimer());
        }
        FollowPlayer();
        EnemyWalking();
        ZDead();
        ZAggrissive();
        ZombieMoan();
    }

    public void ShootEnemy(float damage)
    {
        if(health > 0)
        {
            health -= damage;
            healthSlider.value = health;
            Debug.Log("Health: " + health);
        }
    }

    private void EnemyWalking()
    {
        _t = Time.deltaTime * 0.5f;
        Debug.DrawLine(startPosition, transform.position, Color.red);
        float distance = Vector3.Distance(startPosition, transform.position);
        if(!playerInTarget && distance <= maxDistance && !dead)
        {
            transform.Translate(Vector3.forward * (speed / 20) * Time.deltaTime);

        } else if (!playerInTarget && distance >= maxDistance && !dead)
        {
            startPosition = transform.position;
            RotateEnemy();
            distance = 0;
        }
    }

    private void FollowPlayer()
    {
        if (playerInTarget)
        {
            GameObject[] playersObj = GameObject.FindGameObjectsWithTag("Player");
            if(playersObj.Length > 0  && !dead)
            {
                Vector3 targetPlayer = playersObj[0].transform.position;
                Vector3 directionToPlayer = targetPlayer - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
                DistanceToPlayer(transform.position, targetPlayer);
                lookRotation.x = 0f;
                lookRotation.z = 0f;
                transform.rotation = lookRotation;
                if (!playerCollision)
                {
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }
            }
        }
    }

    private void RotateEnemy()
    {
        transform.Rotate(Vector3.up, 180.0f);
    }

    private void ZDead()
    {
        if(dead && !fall)
        {
            fall = true;
            float delay = 0.4f;
            Invoke("ZombieFallSound", delay);
        }
    }

    private void ZombieFallSound()
    {
        audioSource.PlayOneShot(zombieFall);
    }

    private void ZAggrissive()
    {
        if(!aggressive && playerInTarget && !dead)
        {
            aggressive = true;
            audioSource.PlayOneShot(zombieAgressive);
        }

        if(aggressive && !playerInTarget && !dead)
        {
            aggressive = false;
        }
    }

    private void ZombieMoan()
    {
        if(timer == 0)
        {
            int moanIndex = Random.Range(1, zombieMoans.Length);
            audioSource.PlayOneShot(zombieMoans[moanIndex]);
        }

        if(timer <= moanTime)
        {
            timer += Time.deltaTime;
        }

        if(timer > moanTime)
        {
            timer = 0;
        }
    }

    public void AudioHit()
    {
        audioSource.PlayOneShot(zombieHit);
    }

    public void GetID(int id)
    {
        _id = id;
    }

    public int TakeID()
    {
        return _id;
    }

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(3);
        Instantiate(loot, currentPosition, transform.rotation);
        Destroy(gameObject);
    }

    private void GetTarget()
    {
        playerInTarget = fieldOfVision.TakeTheTarget();
        //playerInTarget = conusCollisionDetect.TakeTheTarget();
    }

    private bool DistanceToPlayer(Vector3 selfPosition, Vector3 targetPosition)
    {
        float distance = Vector3.Distance(selfPosition, targetPosition);
        if(distance < minDistanceToPlayer)
        {
            playerCollision = true;
        }

        if(distance >= minDistanceToPlayer)
        {
            playerCollision = false;
        }

        Debug.Log(distance);
        return playerCollision;
    }

    public bool TakeThePlayerCollision()
    {
        return playerCollision;
    }

    public bool TakeDead()
    {
        return dead;
    }
}

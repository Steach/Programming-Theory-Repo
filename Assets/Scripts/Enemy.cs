using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private GameObject loot;
    private Vector3 currentPosition;
    private float health = 100;
    private bool playerInTarget = false;
    private bool playerCollision = false;
    private bool dead = false;
    private float speed = 10;
    private float maxDistance = 7;
    private Vector3 startPotition;
    private Vector3 endPosition;
    [SerializeField] private ConusCollisionDetect conusCollisionDetect;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
        Debug.Log("Health: " + health);
        startPotition = transform.position;
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
        Debug.DrawLine(startPotition, transform.position, Color.red);
        float distance = Vector3.Distance(startPotition, transform.position);
        Debug.Log(distance);
        if(!playerInTarget && distance <= maxDistance)
        {
            transform.Translate(Vector3.forward * (speed / 20) * Time.deltaTime);
        } else if (distance >= maxDistance)
        {
            startPotition = transform.position;
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z, 1);
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

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(3);
        Instantiate(loot, currentPosition, transform.rotation);
        Destroy(gameObject);
    }

    private void GetTarget()
    {
        playerInTarget = conusCollisionDetect.TakeTheTarget();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            playerCollision = true;
            Debug.Log("At the player");
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            playerCollision = false;
        }
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

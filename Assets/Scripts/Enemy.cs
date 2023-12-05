using System.Collections;
using UnityEngine;
using UnityEngine.AI;
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
    private FieldOfVision fieldOfVision;
    private int _id;
    private GameObject player;
    private Player playerScript;
    private float distToPlayer;
    private NavMeshAgent navMeshAgent;
    private float hearingDistance = 50f;
   

    [Header("Noise")]
    [SerializeField] private Vector3 noiseLoc;
    [SerializeField] private bool hearNoise = false;
    [SerializeField] private float distanceToNoise;

    [Header("Sound")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] zombieMoans;
    [SerializeField] private AudioClip zombieHit;
    [SerializeField] private AudioClip zombieAgressive;
    [SerializeField] private AudioClip zombieFall;
    // Start is called before the first frame update
    void Start()
    {
        FindPlayer();
        navMeshAgent = GetComponent<NavMeshAgent>();
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
        CheckToNoise();
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
        if(!hearNoise)
        {            
            Vector3 localForward = transform.TransformDirection(Vector3.forward);
            Vector3 globalForward = transform.position + localForward;
            navMeshAgent.SetDestination(globalForward);
            if(navMeshAgent.velocity.magnitude < 0.1f)
            {
                float angleOfRotate = Random.Range(-30, 30);
                Vector3 newEulerAngels = transform.eulerAngles;
                newEulerAngels.y += angleOfRotate;
                transform.eulerAngles = newEulerAngels;
            }
        }

        if(hearNoise)
        {
            Vector3 direction = noiseLoc;
            direction.y = 0f;
            direction.Normalize();
            navMeshAgent.SetDestination(noiseLoc);
            if(navMeshAgent.velocity.magnitude < 0.1f)
            {
                float angleOfRotate = Random.Range(170, 180);
                Vector3 newEulerAngels = transform.eulerAngles;
                newEulerAngels.y += angleOfRotate;
                transform.eulerAngles = newEulerAngels;
                hearNoise = false;
            }
        }
    }

    private void FollowPlayer()
    {
        if (playerInTarget)
        {
            navMeshAgent.isStopped = true;
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

    private void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
    }

    private void CheckToNoise()
    {
        if(dead)
        {
            hearNoise = false;
            navMeshAgent.isStopped = true;
        }

        DistanceToPlayer();
        if (distToPlayer <= 50 && playerScript.GetShooting() && !aggressive && !hearNoise)
        {
            Debug.Log("Hear the Noise!");
            Debug.Log(hearNoise);
            noiseLoc = player.transform.position;
            hearNoise = true;
        }

        if (hearNoise)
        {
            distanceToNoise = Vector3.Distance(transform.position, noiseLoc);
        }
    }

    private void DistanceToPlayer()
    {
        if(!playerInTarget)
        {
            Vector3 playerPosition = player.transform.position;
            distToPlayer = Vector3.Distance(transform.position, playerPosition);
        } 
    }
}

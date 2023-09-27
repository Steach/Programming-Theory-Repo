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
    private float speed = 10;
    [SerializeField] private ConusCollisionDetect conusCollisionDetect;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
        Debug.Log("Health: " + health);
    }

    // Update is called once per frame
    void Update()
    {
        GetTarget();
        currentPosition = transform.position;
        if (health <= 0)
        {
            Instantiate(loot, currentPosition, transform.rotation);
            Destroy(gameObject);
        }
        FollowPlayer();
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

    private void FollowPlayer()
    {
        if (playerInTarget)
        {
            GameObject[] playersObj = GameObject.FindGameObjectsWithTag("Player");
            Transform targetPlayer = playersObj[0].GetComponent<Transform>();
            transform.LookAt(targetPlayer);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void GetTarget()
    {
        playerInTarget = conusCollisionDetect.TakeTheTarget();
    }
}

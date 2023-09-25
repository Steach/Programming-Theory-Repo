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
        currentPosition = transform.position;
        if (health <= 0)
        {
            Instantiate(loot, currentPosition, transform.rotation);
            Destroy(gameObject);
        }
        if (playerInTarget)
        {
            Debug.Log("See the player!");
            GameObject[] playersObj = GameObject.FindGameObjectsWithTag("Player");
            Transform targetPlayer = playersObj[0].GetComponent<Transform>();
            transform.LookAt(targetPlayer);
        }
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

    private void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerInTarget = true;
            Debug.Log("See the player!");
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerInTarget = false;
            Debug.Log("Don`t see the player!");
        }
    }
}

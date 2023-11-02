using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider staminaSlider;
    private Moving moving;
    private float health = 100;
    private float stamina = 100;
    private bool playerIsDead = false;
    // Start is called before the first frame update
    void Start()
    {
        moving = GetComponent<Moving>();
        healthSlider.maxValue = health;
        staminaSlider.maxValue = stamina;
        SetHealthSlider(health);
        SetStaminaSlider(stamina);
    }

    // Update is called once per frame
    void Update()
    {
        IsDead();
    }

    public void DamageHealth(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            SetHealthSlider(health);
        }
    }

    public void СonsumptionStamina(float consumption)
    {
        if (stamina > 0)
        {
            stamina -= consumption;
            SetStaminaSlider(stamina);
        }
    }

    public void RecoveryStamina()
    {
        if (stamina < 100)
        {
            stamina += 0.05f;
            SetStaminaSlider(stamina);
        }
    }

    public bool GetStamina()
    {
        if (stamina > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool TakePlayerIsDead()
    {
        return playerIsDead;
    }

    private void IsDead()
    {
        if (health <= 0)
        {
            playerIsDead = true;
        }
    }

    private void SetHealthSlider(float hp)
    {
        healthSlider.value = hp;
    }

    private void SetStaminaSlider(float stam)
    {
        staminaSlider.value = stam;
    }

    private void OnTriggerEnter (Collider other) 
    {
        if(other.CompareTag("EnemyHand"))
        {
            Debug.Log("player was damaged");
            Enemy enemy = GameObject.FindGameObjectWithTag("TargetBody").GetComponent<Enemy>();
            enemy.AudioHit();
            DamageHealth(5f);
            moving.PlayerStabilization();
        }
    }
}

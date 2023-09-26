using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider staminaSlider;
    private float health = 100;
    private float stamina = 100;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = health;
        staminaSlider.maxValue = stamina;
        SetHealthSlider(health);
        SetStaminaSlider(stamina);
    }

    // Update is called once per frame
    void Update()
    {
        
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
            stamina += 0.02f;
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

    private void SetHealthSlider(float hp)
    {
        healthSlider.value = hp;
    }

    private void SetStaminaSlider(float stam)
    {
        staminaSlider.value = stam;
    }
}
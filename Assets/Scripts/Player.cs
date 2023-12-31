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
    private bool isShooting = false;
    private float noiseArea;
    //private MainButton mainButton;
    //private FirstButton firstButton;
    // Start is called before the first frame update
    void Start()
    {
        moving = GetComponent<Moving>();
        //mainButton = GameObject.Find("MainButton").GetComponent<MainButton>();
        //firstButton = GameObject.Find("FirstButton").GetComponent<FirstButton>();
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

        if(other.CompareTag("Button"))
        {
            FirstButton firstButton = other.GetComponent<FirstButton>();
            SecondButton secondButton  = other.GetComponent<SecondButton>();
            ThirdButton thirdButton = other.GetComponent<ThirdButton>();
            MainButton mainButton = other.GetComponent<MainButton>();

            if(mainButton != null)
            {
                mainButton.ShowUIText(true);
            }
            
            if(firstButton != null)
            {
                firstButton.ShowUIText(true);
            }

            if(secondButton != null)
            {
                secondButton.ShowUIText(true);
            }

            if(thirdButton != null)
            {
                thirdButton.ShowUIText(true);
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        FirstButton firstButton = other.GetComponent<FirstButton>();
        SecondButton secondButton  = other.GetComponent<SecondButton>();
        ThirdButton thirdButton = other.GetComponent<ThirdButton>();
        MainButton mainButton = other.GetComponent<MainButton>();
            
        if(mainButton != null)
        {
            mainButton.ShowUIText(false);
        }
            
        if(firstButton != null)
        {
            firstButton.ShowUIText(false);
        }

        if(secondButton != null)
        {
            secondButton.ShowUIText(false);
        }

        if(thirdButton != null)
        {
            thirdButton.ShowUIText(false);
        }
    }

    public void SetShooting(bool shooting, float distance)
    {
        isShooting = shooting;
        noiseArea = distance;
    }

    public (bool, float) GetShooting()
    {
        return (isShooting, noiseArea);
    }
}

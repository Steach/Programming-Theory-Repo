using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float strayfSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float jumpForce;
    private int normalSpeed = 2;
    private int multiplySpeed = 3;
    private Rigidbody playerRB;
    private int jumpDuration = 1;
    private bool onTheGround;
    private bool isSitting = false;
    private Vector3 currentPos;
    private Player player;
    private bool stamina;
    private bool playerIsDead;
    private float consumptionStamina = 0.1f;
    [SerializeField] private GameObject deadScreen;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip stepSound;
    private float stepSoundTiming;
    private bool running = false;
    private float stepTiming = 0.5f;
    // Start is called before the first frame update

    void Start()
    {
        deadScreen.SetActive(false);
        playerRB = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        playerIsDead = player.TakePlayerIsDead();
        if(!playerIsDead)
        {
            ChangeSpeed();
            Jump();
            Sit();
            stamina = player.GetStamina();
            BoolRuninng();
        }
        SetActiveDeadScreen();
    }

    void Movement(int acceleration)
    {
        StartStepAudio();
        float forwardMovement = Input.GetAxis("Vertical") * moveSpeed * acceleration * Time.deltaTime;
        float strayfMovement = Input.GetAxis("Horizontal") * strayfSpeed * acceleration * Time.deltaTime;
        float turnMovement = Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime;

        transform.Translate(Vector3.forward * forwardMovement);
        transform.Translate(Vector3.right * strayfMovement);
        transform.Rotate(Vector3.up * turnMovement);
    }

    void ChangeSpeed()
    {
        if(Input.GetKey(KeyCode.LeftShift) && !isSitting && stamina)
        {
            stepTiming = 0.3f;
            Movement(multiplySpeed);
            player.СonsumptionStamina(consumptionStamina);
        }
        else if(isSitting)
        {
            stepTiming = 0.8f;
            Movement(normalSpeed/2);
            player.RecoveryStamina();
        }
        else
        {
            stepTiming = 0.5f;
            Movement(normalSpeed);
            player.RecoveryStamina();
        }
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && onTheGround && !isSitting)
        {
            playerRB.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.Impulse);
            onTheGround = false;
        }
    }

    private void SetActiveDeadScreen()
    {
        if(playerIsDead)
        {
            deadScreen.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        PlayerStabilization();
        if (other.gameObject.CompareTag("Ground"))
        {
            onTheGround = true;
        }
    //---Trying don`t miss the player---
        if (other.gameObject.CompareTag("Wall"))
        {
            currentPos = transform.position;
        }

        if (other.gameObject.CompareTag("NotWall"))
        {
            transform.position = currentPos;
        }
    //----------------------------------
    }

    private void OnCollisionExit(Collision other) 
    {
        PlayerStabilization();
    }

    private void Sit()
    {
        if(!isSitting)
        {
            currentPos = transform.position;
        }
        
        if(Input.GetKey(KeyCode.LeftControl))
        {
            transform.position = new Vector3(transform.position.x, currentPos.y - 1, transform.position.z);
            isSitting = true;
        }
        else
        {
            transform.position = new Vector3 (transform.position.x, currentPos.y, transform.position.z);
            isSitting = false;
        }
    }

    private void StartStepAudio()
    {
        if(running)
        {
            if(stepSoundTiming == 0)
            {
                audioSource.PlayOneShot(stepSound);
            }

            if(stepSoundTiming < stepTiming)
            {
                stepSoundTiming += Time.deltaTime;
            }

            if(stepSoundTiming >= stepTiming)
            {
                stepSoundTiming = 0;
            }
        }
    }

    private void BoolRuninng()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S))
        {
            running = true;
        }
        else
        {
            running = false;
        }
    }

    public void PlayerStabilization()
    {
        playerRB.velocity = Vector3.zero;
        playerRB.angularVelocity = Vector3.zero;
    }
}

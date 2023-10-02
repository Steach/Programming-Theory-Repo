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
        }
        SetActiveDeadScreen();
    }

    void Movement(int acceleration)
    {
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
            Movement(multiplySpeed);
            player.СonsumptionStamina(consumptionStamina);
        }
        else if(isSitting)
        {
            Movement(normalSpeed/2);
            player.RecoveryStamina();
        }
        else
        {
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

    public void PlayerStabilization()
    {
        playerRB.velocity = Vector3.zero;
        playerRB.angularVelocity = Vector3.zero;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float strayfSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float jumpForce;
    private int normalSpeed = 1;
    private int multiplySpeed = 2;
    private Rigidbody playerRB;
    private int jumpDuration = 1;
    // Start is called before the first frame update

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {     
        ChangeSpeed();
        Jump();
    }

    void Movement(int acceleration)
    {
        Debug.Log(acceleration);
        float forwardMovement = Input.GetAxis("Vertical") * moveSpeed * acceleration * Time.deltaTime;
        float strayfMovement = Input.GetAxis("Horizontal") * strayfSpeed * acceleration * Time.deltaTime;
        float turnMovement = Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime;

        transform.Translate(Vector3.forward * forwardMovement);
        transform.Translate(Vector3.right * strayfMovement);
        transform.Rotate(Vector3.up * turnMovement);
    }

    void ChangeSpeed()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            Movement(multiplySpeed);
        }
        else
        {
            Movement(normalSpeed);
        }
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.Impulse);
            StopJump();
        }
    }

    IEnumerator StopJump()
    {
        yield return new WaitForSeconds(jumpDuration);
        playerRB.velocity = Vector3.zero;
    }
}

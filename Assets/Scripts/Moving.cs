using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float strayfSpeed;
    [SerializeField] private float turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float forwardMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float strayfMovement = Input.GetAxis("Horizontal") * strayfSpeed * Time.deltaTime;
        float turnMovement = Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime;

        transform.Translate(Vector3.forward * forwardMovement);
        transform.Translate(Vector3.right * strayfMovement);
        transform.Rotate(Vector3.up * turnMovement);
    }
}

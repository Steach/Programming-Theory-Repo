using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning : MonoBehaviour
{
    [SerializeField] private float turnSpeed;
    private Vector3 turnAngles;
    private float xRotation = 40f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
    }

    void Turn()
    {
        float rotationX = transform.localEulerAngles.x;
        
        if (rotationX > 180)
        {
            rotationX -= 360;
        }

        float newRotationX = rotationX - Input.GetAxis("Mouse Y") * turnSpeed * Time.deltaTime;
        newRotationX = Mathf.Clamp(newRotationX, -xRotation, xRotation);

        if (newRotationX < 0)
        {
            newRotationX += 360;
        }

        transform.localEulerAngles = new Vector3(newRotationX, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}

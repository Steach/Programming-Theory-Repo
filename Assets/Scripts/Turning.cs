using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning : MonoBehaviour
{
    [SerializeField] private float turnSpeed;
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
        float inclineMovement = Input.GetAxis("Mouse Y") * turnSpeed * Time.deltaTime;
        transform.Rotate(Vector3.left * inclineMovement);
    }
}

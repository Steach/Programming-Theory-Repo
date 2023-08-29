using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    [SerializeField] private Transform weaponTransform;
    private float recoilForce = 0.1f;

    void Update()
    {
        Recoiling();
    }

    private void Recoiling()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            float recoilRotationX = transform.localEulerAngles.x;
            float newRecoilRotationX = recoilRotationX - recoilForce;
            transform.localEulerAngles = new Vector3(newRecoilRotationX, transform.localEulerAngles.y, transform.localEulerAngles.z); 
        }  
    }
}

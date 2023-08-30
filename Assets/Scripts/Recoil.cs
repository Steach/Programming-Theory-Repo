using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    [SerializeField] private Transform weaponTransform;

    public void Recoiling(float recoilForce)
    {
        float recoilRotationX = transform.localEulerAngles.x;
        float newRecoilRotationX = recoilRotationX - recoilForce;
        transform.localEulerAngles = new Vector3(newRecoilRotationX, transform.localEulerAngles.y, transform.localEulerAngles.z); 
    }
}

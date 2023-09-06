using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField] private GameObject assaultRifle;
    //[SerializeField] private GameObject sniperRifle;
    [SerializeField] private GameObject handGun;
    // Start is called before the first frame update
    void Start()
    {
        assaultRifle.SetActive(true);
        //sniperRifle.SetActive(false);
        handGun.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ChooseWeapon();
    }

    void ChooseWeapon()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            assaultRifle.SetActive(true);
            //sniperRifle.SetActive(false);
            handGun.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            assaultRifle.SetActive(false);
            //sniperRifle.SetActive(true);
            handGun.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            assaultRifle.SetActive(false);
            //sniperRifle.SetActive(false);
            handGun.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField] private GameObject assaultRifle;
    [SerializeField] private GameObject sniperRifle;
    [SerializeField] private GameObject handGun;
    private bool weaponIsActive = false;
    private int weaponIndex;
    // Start is called before the first frame update
    void Start()
    {
        assaultRifle.SetActive(!weaponIsActive);
        sniperRifle.SetActive(weaponIsActive);
        handGun.SetActive(weaponIsActive);
        weaponIsActive = true;
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
            EnableAR();
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            EnableSR();
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            EnableHG();
        }
    }

    private void EnableAR()
    {
        weaponIndex = 0;
        ChooseWeapon2(assaultRifle, weaponIndex);
    }

    private void EnableSR()
    {
        weaponIndex = 1;
        ChooseWeapon2(sniperRifle, weaponIndex);
    }

    private void EnableHG()
    {
        weaponIndex = 2;
        ChooseWeapon2(handGun, weaponIndex);
    }

    private void DisableWeapons()
    {
        weaponIsActive = false;
        assaultRifle.SetActive(weaponIsActive);
        sniperRifle.SetActive(weaponIsActive);
        handGun.SetActive(weaponIsActive);
    }

    private void ChooseWeapon2(GameObject weapon, int index)
    {
        EBulletsNum bulIndex = (EBulletsNum) index;

        switch(bulIndex)
        {
            case EBulletsNum.assault:
            {
                weapon = assaultRifle;
            }
            break;

            case EBulletsNum.sniper:
            {
                weapon = sniperRifle;
            }
            break;

            case EBulletsNum.handgun:
            {
                weapon = handGun;
            }
            break;
        }

        DisableWeapons();
        weapon.SetActive(true);
    }
}

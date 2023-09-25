using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifle : Weapon
{

    private Vector3 offsetForePos;
    private float fireTimeout;
    private float fireRatePS = 1f;
    protected int weaponIndex = 1;
    private int currentClipCapacity;
    [SerializeField] private Canvas defaultCanvas;
    [SerializeField] private Canvas aimCanvas;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera aimCamera;
    // Start is called before the first frame update
    void Start()
    {
        fireTimeout = 0;
        clipCapacity = 5;
        shotsPerMin = 1;
        reloadTime = 3;
        kickbacklForce = 3;
        damagePoint = 75;
        recoilForce = 2f;
        RealodingText(currentClipCapacity);
        currentClipCapacity = clipCapacity;
        shootExplosion.Stop();
        reloadSlider.maxValue = reloadTime;
        reloadSlider.value = reloadTime;
        reloadSlider.gameObject.SetActive(false);
        reloadable = Reloadable(currentClipCapacity, clipCapacity, weaponIndex, reloadSlider.value, reloadTime);
    }

    // Update is called once per frame
    void Update()
    {
        AimPos();
        reloadingText.text = RealodingText(currentClipCapacity);
        bulletText.text = AmmoText(currentClipCapacity, weaponIndex);
        reloadSlider.value = ReloadSliderValue(reloadSlider, reloadSlider.value, reloadTime, reloadable);
        fireTimeout += Time.deltaTime;
        AssaultShoot();
        currentClipCapacity = Reload(currentClipCapacity, clipCapacity, weaponIndex, reloadSlider.value);
        reloadable = Reloadable(currentClipCapacity, clipCapacity, weaponIndex, reloadSlider.value, reloadTime);
    }

    private void AssaultShoot()
    {
        if (fireTimeout >= (1f / fireRatePS) && currentClipCapacity > 0 && Input.GetKeyDown(KeyCode.Mouse0) && reloadSlider.value >= reloadTime)
        {
            Shoot(bulletPrefab, firePosition, shootExplosion, recoilForce);
            currentClipCapacity -= 1;
            fireTimeout = 0f;
        }
        else
        {
            shootExplosion.Stop();
        }
    }

    public int GetWeapIndex()
    {
        return weaponIndex;
    }

    private void AimPos()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            AimPosition(gameObject);
            aiming = true;
            SetActiveSniperAims();
        }
        else
        {
            
            gameObject.transform.position = defaultPosition.position;
            aiming = false;
            SetActiveSniperAims();
        }
    }

    private void SetActiveSniperAims()
    {
        defaultCanvas.gameObject.SetActive(!aiming);
        mainCamera.gameObject.SetActive(!aiming);
        aimCanvas.gameObject.SetActive(aiming);
        aimCamera.gameObject.SetActive(aiming);
    }
}

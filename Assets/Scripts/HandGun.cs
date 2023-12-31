using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : Weapon
{
    private Vector3 offsetForePos;
    private float fireTimeout;
    private float fireRatePS = 11.6f;
    protected int weaponIndex = 2;
    private int currentClipCapacity;
    // Start is called before the first frame update
    void Start()
    {
        FindPlayer();
        fireTimeout = 0;
        clipCapacity = 8;
        hearingDistance = 25f;
        shotsPerMin = 1;
        reloadTime = 1;
        kickbacklForce = 3;
        damagePoint = 5;
        recoilForce = 0.5f;
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
            Shoot(bulletPrefab, firePosition, shootExplosion, recoilForce, shootAudioClip, playAudio);
            currentClipCapacity -= 1;
            fireTimeout = 0f;
            player.SetShooting(true, hearingDistance);
        }
        else
        {
            shootExplosion.Stop();
            player.SetShooting(false, hearingDistance);
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
        }
        else
        {
            gameObject.transform.position = defaultPosition.position;
            aiming = false;
        }
    }
}

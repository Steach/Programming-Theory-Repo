using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Weapon
{
    private Vector3 offsetForePos;
    private float fireTimeout;
    private float fireRatePS = 11.6f;
    protected int weaponIndex = 0;
    private int currentClipCapacity;
    // Start is called before the first frame update
    void Start()
    {
        FindPlayer();
        aiming = false;
        isShooting = false;
        fireTimeout = 0;
        clipCapacity = 20;
        shotsPerMin = 1;
        reloadTime = 2;
        kickbacklForce = 3;
        damagePoint = 7;
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
        if (fireTimeout >= (1f / fireRatePS) && currentClipCapacity > 0 && Input.GetKey(KeyCode.Mouse0) && reloadSlider.value >= reloadTime)
        {
            Shoot(bulletPrefab, firePosition, shootExplosion, recoilForce, shootAudioClip, playAudio);
            currentClipCapacity -= 1;
            fireTimeout = 0f;
            player.SetShooting(true);
        }
        else
        {
            shootExplosion.Stop();
            player.SetShooting(false);
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
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    protected int clipCapacity;
    protected int shotsPerMin;
    protected float reloadTime;
    protected float kickbacklForce;
    protected float damagePoint;
    protected float bulletSpeed;
    protected float recoilForce;
    protected int oneMin = 60;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform firePosition;
    [SerializeField] protected TextMeshProUGUI reloadingText;
    [SerializeField] protected ParticleSystem shootExplosion;
    [SerializeField] protected TextMeshProUGUI bulletText;
    [SerializeField] protected Transform aimPosition;
    [SerializeField] protected Transform defaultPosition;
    [SerializeField] protected Slider reloadSlider;
    [SerializeField] protected AudioClip shootAudioClip;
    [SerializeField] protected AudioSource playAudio;
    protected Recoil recoil;
    private int bullets;
    private Inventory inventory;
    protected Vector3 currentPos;
    protected bool aiming;
    protected bool reloadable;
    protected bool isShooting;
    protected Player player;
    protected float hearingDistance;
    
    void Awake()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
    void Update()
    {
        
    }

    virtual protected void Shoot(GameObject bulPrefab, Transform firePos, ParticleSystem shootPrticle, float recoilF, AudioClip shootAudio, AudioSource source)
    {
        recoil = GameObject.Find("Head").GetComponent<Recoil>();
        source.PlayOneShot(shootAudio);
        GameObject bulletInstance = Instantiate(bulPrefab, firePos.position, firePos.rotation) as GameObject;
        recoil.Recoiling(recoilF);
        shootPrticle.Play();
    }

    virtual protected int Reload(int currentClipCapacity, int clipCap, int weaponID, float relTimeSlider)
    { 
        if (Input.GetKeyDown(KeyCode.R))
        {
            int ammoCapacity = clipCap - currentClipCapacity;
            bullets = inventory.BulletsStuff(weaponID);

            if (bullets > ammoCapacity)
            {
                currentClipCapacity += ammoCapacity;
                inventory.BulletsStuff(weaponID, ammoCapacity);
                ammoCapacity = 0;
            }
            else if (bullets <= ammoCapacity)
            {
                currentClipCapacity += bullets;
                inventory.BulletsStuff(weaponID, bullets);
                ammoCapacity = 0;
            }
        }
        return currentClipCapacity;
    }

    virtual protected string RealodingText(int currentClipCapacity)
    {
        if (currentClipCapacity > 0)
        {
            return "";      
        }
        else
        {
            return "No ammo. Need to reload.";
        }
    }

    virtual protected float ReloadSliderValue(Slider slider, float relSliderTime, float relTime, bool _reloadable)
    {
        if(_reloadable)
        {
            if(Input.GetKeyDown(KeyCode.R) || relSliderTime < relTime)
                {
                    if (relSliderTime > 0)
                    {
                        slider.gameObject.SetActive(true);
                        relSliderTime -= Time.deltaTime;
                        return relSliderTime;
                    }
                    else 
                    {
                        slider.gameObject.SetActive(false);
                        relSliderTime = relTime;
                        return relSliderTime;
                    }
                }
            return relTime;
        }
        else
        {
            return relTime;
        }
    }

    virtual protected bool Reloadable(int curClipCap, int clipCap, int weaponID, float relSliderTime, float relTime)
    {
        if (inventory.BulletsStuff(weaponID) <= 0 && relSliderTime >= relTime)
        {
            return false;
        }

        if (curClipCap == clipCap && relSliderTime >= relTime)
        {
            return false;
        }

        return true;
    }

    virtual protected string AmmoText(int currentClipCapacity, int weaponID)
    {
        string bulletsStr = "Bullets: " + currentClipCapacity + "/" + inventory.BulletsStuff(weaponID);
        return bulletsStr;
    }

    virtual protected void AimPosition(GameObject weapon)
    {
        weapon.transform.position = new Vector3(aimPosition.transform.position.x, aimPosition.transform.position.y, aimPosition.transform.position.z);
    }

    virtual protected void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
}

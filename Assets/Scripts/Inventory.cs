using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Inventory : MonoBehaviour
{
    private static Inventory instance;
    private int assaultBullets;
    private int sniperBullets;
    private int handgunBullets;
    private EBulletsNum currentBulNum;
    public static int invInstance;

    public static Inventory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Inventory>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    instance = obj.AddComponent<Inventory>();
                }
            }
            return instance;
        }
    }

    private int AssaultBullets
    {
        get {return assaultBullets; }
        set {assaultBullets = value; }
    }

    private int SniperBullets
    {
        get {return sniperBullets; }
        set {sniperBullets = value; }
    }

    private int HandgunBullets
    {
        get {return handgunBullets; }
        set {handgunBullets = value; }
    }

    void Awake()
    {
        AssaultBullets = 60;
        SniperBullets = 30;
        HandgunBullets = 32;
        invInstance++;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            //Destroy(gameObject);
        }
    }

    private void OnDestroy() 
    {
        invInstance--;
        //Debug.Log("OnDestroy invInstance: " + invInstance);
    }
    
    public void DebugMethod()
    {
        AssaultBullets += 120;
        SniperBullets += 30;
        HandgunBullets += 32;
        //Debug.Log("Bullets++: " + AssaultBullets + " " + SniperBullets + " " + HandgunBullets);
    }

    public void BulletsStuff(int bulNum, int clips)
    {
        EBulletsNum commingBullet = (EBulletsNum) bulNum;

        switch(commingBullet)
        {
            case EBulletsNum.assault:
            {
                int bullets = Inventory.Instance.AssaultBullets;
                if(bullets > 0)
                {
                    Inventory.Instance.AssaultBullets -= clips;
                }
            }
            break;

            case EBulletsNum.sniper:
            {
                int bullets = Inventory.Instance.SniperBullets;
                if(bullets > 0)
                {
                    Inventory.Instance.SniperBullets -= clips;
                }
            }
            break;

            case EBulletsNum.handgun:
            {
                int bullets = Inventory.Instance.HandgunBullets;
                if(bullets > 0)
                {
                    Inventory.Instance.HandgunBullets -= clips;
                }
            }
            break;

            default: break;
        }
    }

    public int BulletsStuff(int bulNum)
    {
        EBulletsNum commingBullet = (EBulletsNum) bulNum;

        switch(commingBullet)
        {
            case EBulletsNum.assault:
            {
                int bullets = Inventory.Instance.AssaultBullets;
                return bullets;
            }

            case EBulletsNum.sniper:
            {
                int bullets = Inventory.Instance.SniperBullets;
                return bullets;
            }

            case EBulletsNum.handgun:
            {
                int bullets = Inventory.Instance.HandgunBullets;
                return bullets;
            }
            default: return 0;
        }
    }

}

public enum EBulletsNum
{
    assault = 0,
    sniper,
    handgun,
    none
}

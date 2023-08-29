using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    private static Inventory instance;
    private int assaultBullets;
    private int sniperBullets;
    private int handgunBullets;
    private EBulletsNum currentBulNum;

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
        assaultBullets = 60;
        sniperBullets = 30;
        handgunBullets = 32;

        /*if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);*/
    }
    
    protected void DebugMethod()
    {
        AssaultBullets += 120;
    }

    protected void BulletsStuff(int bulNum, int clips)
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

    protected int BulletsStuff(int bulNum)
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

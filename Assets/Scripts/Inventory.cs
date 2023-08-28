using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    private static Inventory instance;
    protected int assaultBullets {get; private set;}
    protected int sniperBullets {get; private set;}
    protected int handgunBullets {get; private set;}
    private EBulletsNum currentBulNum;
    [SerializeField] protected TextMeshProUGUI bulletText;

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

    public int AssaultBullets
    {
        get {return assaultBullets; }
        set {assaultBullets = value; }
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
        assaultBullets += 120;
        Debug.Log("Debug Inventory: " + assaultBullets);
    }

    protected void BulletsStuff(int bulNum, int clips)
    {
        EBulletsNum commingBullet = (EBulletsNum) bulNum;

        switch(commingBullet)
        {
            case EBulletsNum.assault:
            {
                if(assaultBullets > 0)
                {
                    assaultBullets -= clips;
                }
            }
            break;

            case EBulletsNum.sniper:
            {
                if(sniperBullets > 0)
                {
                    sniperBullets -= clips;
                }
            }
            break;

            case EBulletsNum.handgun:
            {
                if(handgunBullets > 0)
                {
                    handgunBullets -= clips;
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
                Debug.Log("Invetory: " + assaultBullets);
                return assaultBullets;
            }

            case EBulletsNum.sniper:
            {
                return sniperBullets;
            }

            case EBulletsNum.handgun:
            {
                return handgunBullets;
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

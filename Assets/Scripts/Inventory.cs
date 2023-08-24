using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    protected int assaultBullets {get; private set;}
    protected int sniperBullets {get; private set;}
    protected int handgunBullets {get; private set;}
    private EBulletsNum currentBulNum;
    [SerializeField] protected TextMeshProUGUI bulletText;

    void Awake()
    {
        assaultBullets = 60;
        sniperBullets = 30;
        handgunBullets = 32;
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

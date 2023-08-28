using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    private int assaultBullets; // {get; private set;}
    protected int sniperBullets {get; private set;}
    protected int handgunBullets {get; private set;}
    private EBulletsNum currentBulNum;

    void Awake()
    {
        assaultBullets = 60;
        sniperBullets = 30;
        handgunBullets = 32;
    }
    
    public void DebugMethod()
    {
        assaultBullets += 120;
    }

    public void BulletsStuff(int bulNum, int clips)
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

    public int BulletsStuff(int bulNum)
    {
        EBulletsNum commingBullet = (EBulletsNum) bulNum;
        switch(commingBullet)
        {
            case EBulletsNum.assault:
            {
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

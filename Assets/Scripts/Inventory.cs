using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    protected int assaultBullets = 60;
    protected int sniperBullets = 30;
    protected int handgunBullets = 32;
    private EBulletsNum currentBulNum;
    [SerializeField] protected TextMeshProUGUI bulletText;
    
    virtual protected void BulletsStuff(int bulNum, int clips)
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

    virtual protected int BulletsStuff(int bulNum)
    {
        EBulletsNum commingBullet = (EBulletsNum) bulNum;

        switch(commingBullet)
        {
            case EBulletsNum.assault:
            {
                if(assaultBullets > 0)
                {
                    return assaultBullets;
                }
            }
            break;

            case EBulletsNum.sniper:
            {
                if(sniperBullets > 0)
                {
                    return sniperBullets;
                }
            }
            break;

            case EBulletsNum.handgun:
            {
                if(handgunBullets > 0)
                {
                    return handgunBullets;
                }
            }
            break;

            default: return 0;
        }

        return 0;
    }
}

public enum EBulletsNum
{
    assault = 0,
    sniper,
    handgun,
    none
}

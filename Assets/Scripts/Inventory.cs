using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    protected int assaultBullets = 60;
    protected int sniperBullets = 30;
    protected int handgunBullets = 32;
    private EBulletsNum currentBulNum;
    virtual protected void Assault(int bulNum)
    {
        EBulletsNum commingBullet = (EBulletsNum) bulNum;
        

        switch(bulNum)
        {
            case EBulletsNum.assault:
            {
                assaultBullets -= 1;
                Debug.Log(assaultBullets);
            }
            break;

            case EBulletsNum.sniper:
            {
                sniperBullets -= 1;
                Debug.Log(sniperBullets);
            }
            break;

            case EBulletsNum.handgun:
            {
                handgunBullets -= 1;
                Debug.Log(handgunBullets);
            }
            break;

            default: break;

        }
        assaultBullets -= 1;
    }
}

public enum EBulletsNum
{
    assault = 0,
    sniper,
    handgun,
    none
}

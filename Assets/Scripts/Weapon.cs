using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected int clipCapacity;
    protected int shotsPerMin;
    protected float reloadTime;
    protected float kickbacklForce;
    protected float damagePoint;
    protected int oneMin = 60;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public int CalcSPM(int clip, int reload)
    {
        float countpermin = oneMin/(clip + reload);
        int spm = Mathf.RoundToInt(countpermin * clip);
        return spm;
    }*/
}

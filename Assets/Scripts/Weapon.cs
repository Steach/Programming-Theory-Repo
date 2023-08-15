using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int clipCapacity {get; set;}
    public int shotsPerMin {get; set;}
    public float reloadTime {get; set;}
    public float kickbacklForce {get; set;}
    public float damagePoint {get; set;}
    private int oneMin = 60;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int CalcSPM(int clip, int reload)
    {
        float countpermin = oneMin/(clip + reload);
        int spm = Mathf.RoundToInt(countpermin * clip);
        return spm;
    }
}

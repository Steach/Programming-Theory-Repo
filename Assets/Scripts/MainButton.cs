using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainButton : Button
{    
    // Start is called before the first frame update
    void Start()
    {
        lockedColor = new Color(1, 0, 0, 1);
        unlockedColor = new Color(0, 1, 0, 1);
        nearTheButton = false;
    }

    // Update is called once per frame
    void Update()
    {
        PressButton();
        UnlockedButton();
    }

    public void SetFirstKey(bool key)
    {
        firstKey = key;
    }

    public void SetSecondKey(bool key)
    {
        secondKey = key;
    }

    public void SetThirdKey(bool key)
    {
        thirdKey = key;
    }
}

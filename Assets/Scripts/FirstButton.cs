using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstButton : Button
{
    // Start is called before the first frame update
    void Start()
    {
        lockedColor = new Color(1, 0, 0, 1);
        unlockedColor = new Color(0, 1, 0, 1);
        nearTheButton = false;
        FindMainButton();
    }

    // Update is called once per frame
    void Update()
    {
        PressButton();
        UnlockedButton();
    }

    protected override void UnlockedButton()
    {
        light.color = unlockedColor;
    }

    protected override void PressButton()
    {
        base.PressButton();
        if(nearTheButton && Input.GetKeyDown(KeyCode.E))
        {
            mainButton.SetFirstKey(true);
            mainButton.SetSecondKey(true);
            mainButton.SetThirdKey(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExitButton : MonoBehaviour
{
    [SerializeField] private GameObject exitText;
    private bool nearTheButton = false;
    [SerializeField] private Animator animator;
    public bool firstKey = false;
    public bool secondKey = false;
    public bool thirdKey = false;
    [SerializeField] private Light light;
    private Color lockedColor = new Color(1, 0, 0, 1);
    private Color unlockedColor = new Color(0, 1, 0, 1);

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PressButton();
        UnlockedButton();
    }

    public void PressButton()
    {
        if(nearTheButton && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("NearTheBotton", true);
        }
        else
        {
            animator.SetBool("NearTheBotton", false);
        }
    }

    public void ShowUIText(bool isActive)
    {
        exitText.SetActive(isActive);
        nearTheButton = isActive;
    }

    private void UnlockedButton()
    {
        if(firstKey && secondKey && thirdKey)
        {
            light.color = unlockedColor;
        }
        else
        {
            light.color = lockedColor;
        }
    }
}

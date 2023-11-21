using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class Button : MonoBehaviour
{
    [SerializeField] protected GameObject exitText;
    protected bool nearTheButton = false;
    [SerializeField] protected Animator animator;
    public bool firstKey = false;
    public bool secondKey = false;
    public bool thirdKey = false;
    [SerializeField] protected Light light;
    protected Color lockedColor;
    protected Color unlockedColor;
    protected MainButton mainButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void UnlockedButton()
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

    public virtual void ShowUIText(bool isActive)
    {
        exitText.SetActive(isActive);
        nearTheButton = isActive;
    }

    protected virtual void PressButton()
    {
        if(nearTheButton && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("NearTheBotton", true);
            Debug.Log("Pressed Button");
        }
        else
        {
            animator.SetBool("NearTheBotton", false);
        }
    }

    protected virtual void FindMainButton()
    {
        mainButton = GameObject.Find("MainButton").GetComponent<MainButton>();
    }
}

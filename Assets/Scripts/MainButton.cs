using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainButton : Button
{    
    // Start is called before the first frame update
    void Start()
    {
        lockedColor = new Color(1, 0, 0, 1);
        unlockedColor = new Color(0, 1, 0, 1);
        nearTheButton = false;
        winOnject.SetActive(false);
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

    protected override void PressButton()
    {
        base.PressButton();
        if(nearTheButton && Input.GetKeyDown(KeyCode.E) && firstKey && secondKey && thirdKey)
        {
            winOnject.SetActive(true);
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("TargetBody");
            int enemiesCount = enemies.Length;

            foreach (GameObject enemy in enemies)
            {
                Enemy enemyComponent = enemy.GetComponent<Enemy>();
                if(enemyComponent != null)
                {
                    enemyComponent.ShootEnemy(101);
                }
            }

            StartCoroutine(ChangeColor());
        }
    }

    IEnumerator ChangeColor()
    {
        Image panelImage = panel.GetComponent<Image>();
        Color startColor = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, 0f);
        float elapsed = 0;

        while(elapsed < duration)
        {
            elapsed += Time.deltaTime;
            panelImage.color = Color.Lerp(startColor, targetColor, elapsed / duration);
            yield return null;
        }
        panelImage.color = targetColor;
        Application.Quit();
    }
}

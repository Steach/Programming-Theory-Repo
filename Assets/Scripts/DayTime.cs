using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTime : MonoBehaviour
{
    private float dayLength = 600;
    private float startDay = 0;
    private float endDay = 190;
    private float timer = 0;
    private float currentRotationX = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotationAndCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator RotationAndCountdown()
    {
        while (timer < dayLength)
        {
            float targetRorationX = Mathf.Lerp(startDay, endDay, timer / dayLength);
            currentRotationX = targetRorationX;
            transform.rotation = Quaternion.Euler(currentRotationX, 0, 0);
            timer += Time.deltaTime;
            yield return null;
        }
        yield break;
    }
}

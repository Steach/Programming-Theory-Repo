using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    private float countdownTime = 600.0f;
    // Start is called before the first frame update
    void Start()
    {
        timeText.text = "00:00";
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Countdown()
    {
        while (countdownTime > 0.0f)
        {
            int minutes = Mathf.FloorToInt(countdownTime / 60);
            int seconds = Mathf.FloorToInt(countdownTime % 60);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            countdownTime -= Time.deltaTime;

            yield return null;
        }
        timeText.text = "00:00";
    }
}

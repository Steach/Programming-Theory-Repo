using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlinking : MonoBehaviour
{
    private Light light;
    private float minInterval = 0.1f;
    private float maxInterval = 1.3f;
    private float timer = 0;
    public bool lightOn = true; 
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        EnableLight();
    }

    private bool RandomBlinking()
    {
        bool result = false;
        if(timer <= 0)
        {
            timer = Random.Range(minInterval, maxInterval);
            result = true;
            return result;
        }

        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }

        return result;
    }

    private void EnableLight()
    {
        if(RandomBlinking())
        {
            lightOn = !lightOn;
            light.enabled = lightOn;
        }
    }
}

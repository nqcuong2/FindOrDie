using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public GameObject[] lights;
    public Light[] lightObjects;
    public static bool lightsOn = false;
    public static bool lightsOff = false;
    // Start is called before the first frame update
    void Start()
    {
        lightObjects = new Light[lights.Length];
        for (int i = 0; i < lights.Length; i++)
        {
            lightObjects[i] = lights[i].GetComponent<Light>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lightsOn)
        {
            StartCoroutine(LightsOn(0.0f));
        }
        else if (lightsOff)
        {
            StartCoroutine(LightsFadeOff(0.0f, 2.7f));
            StartCoroutine(LightsOn(0.3f));
            StartCoroutine(LightsFadeOff(0.5f, 3.0f));
            StartCoroutine(LightsOn(0.8f));
            StartCoroutine(LightsFadeOff(1.0f, 3.4f));
        }
    }

    IEnumerator LightsOn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        for (int i = 0; i < lights.Length; i++)
        {
            lightObjects[i].intensity = 0.5f;
        }
        lightsOn = false;
    }

    IEnumerator LightsFadeOff(float waitTime, float fadeMultiplier)
    {
        yield return new WaitForSeconds(waitTime);
        for (int i = 0; i < lights.Length; i++)
        {
            lightObjects[i].intensity -= fadeMultiplier * Time.deltaTime;
        }
        if (lightObjects[0].intensity <= 0.0f)
        {
            lightsOff = false;
        }
    }
}

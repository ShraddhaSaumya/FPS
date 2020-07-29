using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float intensityDecay = 0.15f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minangle =40f;
    Light mylight;

    private void Start()
    {
        mylight = GetComponent<Light>();
    }
    private void Update()
    {
        ReduceLightIntensity();
        ReduceAngle();
    }

    public void addIntensity(float addInten)
    {
        mylight.intensity += addInten;
    }

    public void restoreAngle(float restoreSpot)
    {
        mylight.spotAngle = restoreSpot;
    }

    private void ReduceAngle()
    {
        if (mylight.spotAngle < minangle)
        {
            return;
        }
        else
        {
            mylight.spotAngle -= angleDecay * Time.deltaTime;
        }
    }

    private void ReduceLightIntensity()
    {
        mylight.intensity -= intensityDecay * Time.deltaTime;
    }
}

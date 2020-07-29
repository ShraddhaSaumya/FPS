using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCam;
    [SerializeField] float zoomInFOV = 30f;
    [SerializeField] float zoomOutFOV = 60f;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = .75f;

    bool zoomedInToggle = false; 

    [SerializeField] RigidbodyFirstPersonController fpsCont;

    private void OnDisable()  // when you leave this weapon 
    {
        ZoomedOut();
    }

    void Update()
    {
        ZoomIO();
    }

    private void ZoomIO()
    {
        if (Input.GetMouseButtonDown(1))
        {           
             if(zoomedInToggle == false)
             {
                ZoomedIn();
             }
             else
             {
                ZoomedOut();
             }
        }
    }

    private void ZoomedOut()
    {
        zoomedInToggle = false;
        fpsCam.fieldOfView = zoomOutFOV;
        fpsCont.mouseLook.XSensitivity = zoomOutSensitivity;
        fpsCont.mouseLook.YSensitivity = zoomOutSensitivity;
    }

    private void ZoomedIn()
    {
        zoomedInToggle = true;
        fpsCam.fieldOfView = zoomInFOV;
        fpsCont.mouseLook.XSensitivity = zoomInSensitivity;
        fpsCont.mouseLook.YSensitivity = zoomInSensitivity;
    }
}

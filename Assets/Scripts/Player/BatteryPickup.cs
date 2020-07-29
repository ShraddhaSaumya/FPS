using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float addIntensity=2f;
    [SerializeField] float restoreSpotAngle =80f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponentInChildren<FlashLightSystem>().addIntensity(addIntensity);
            other.gameObject.GetComponentInChildren<FlashLightSystem>().restoreAngle(restoreSpotAngle);
            Destroy(gameObject);
        }
    }
}

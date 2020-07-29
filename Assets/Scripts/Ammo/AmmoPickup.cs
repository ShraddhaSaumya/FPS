using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int pickupAmmoAmount = 15;
    [SerializeField] AmmoType ammoType;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            FindObjectOfType<Ammo>().increaseCurrAmmo(ammoType, pickupAmmoAmount);            
            Destroy(gameObject);
        }
    }
}

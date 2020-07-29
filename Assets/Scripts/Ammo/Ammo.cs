using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot // nested class accessible to ammo only
    {
        public AmmoType ammoType; // public accessible to ammo i.e. outside the ammoSlot too
        public int ammoAmount;
    }

    public int GetCurrAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    public void reduceCurrAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }

    public void increaseCurrAmmo(AmmoType ammoType, int ammoPickup)
    {
        GetAmmoSlot(ammoType).ammoAmount+=ammoPickup;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}

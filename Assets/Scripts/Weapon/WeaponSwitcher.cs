using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currWeapon = 0;

    void Start()
    {
        setWeaponActive();
    }

    void Update()
    {
        int prevWeapon = currWeapon;

        ProcessKeyInput();
        ProcessScrollInput();

        if (prevWeapon != currWeapon)
        {
            setWeaponActive();
        }
    }

    private void ProcessScrollInput()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0) // in upward direction-- less than for order of weapons
        {
            if (currWeapon >= transform.childCount - 1)
            {
                currWeapon = 0;
            }
            else
                currWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0) // in downward direction--greater than for order of weapons
        {
            if (currWeapon <= 0)
            {
                currWeapon = transform.childCount - 1 ;
            }
            else
                currWeapon--;
        }
    }

    private void ProcessKeyInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currWeapon = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currWeapon = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currWeapon = 2;
        }
    }

    private void setWeaponActive()
    {
        int weaponIndex = 0;
        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currWeapon)
                weapon.gameObject.SetActive(true);
            else 
                weapon.gameObject.SetActive(false);
            weaponIndex++;
        }
    }
}

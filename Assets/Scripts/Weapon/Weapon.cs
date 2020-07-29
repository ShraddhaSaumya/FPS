using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCam;
    [SerializeField] float range = 100f;
    [SerializeField] float Damage = 30f;

    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitFlash;

    [SerializeField] AmmoType ammoType;
    [SerializeField] Ammo ammoSlot; // this will be used for ammo class
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] AudioClip audClip;
    [SerializeField] AudioSource audSource;

    bool canShoot = true;

    [SerializeField] TextMeshProUGUI ammoText;

    private void OnEnable()   // when this class instance is made as in here weapon is switched
    {
        canShoot = true;
    }
    
    void Update()
    {
        DisplayAmmo();

        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrAmmo(ammoType);
        String currAmmoName = ammoType.ToString();
        ammoText.text = currAmmoName +" : " + currentAmmo.ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.reduceCurrAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        audSource.PlayOneShot(audClip);
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        if (Physics.Raycast(FPCam.transform.position, FPCam.transform.forward, out RaycastHit hit, range))
        {
            CreateHitEffect(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return; // when enemy died
            target.TakeDamage(Damage);
        }
        else
        {
            return; // hitting sky
        }
    }

    private void CreateHitEffect(RaycastHit hit)
    {
        // instantiate particle effect
        // to destroy keep it as a gameobj
        GameObject impact = Instantiate(hitFlash, hit.transform.position, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}

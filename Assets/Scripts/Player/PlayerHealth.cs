using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource audioSource;

    public void TakeDamage(float Damage)
    {
        hitPoints = hitPoints - Damage;
        if (hitPoints <= 0)
        {
            //audbg.Stop();
            DeathHandler dh = GetComponent<DeathHandler>();
            dh.HandleDeath();
            audioSource.Stop();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 40f; //player health

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();  // or can be done using checking tags
    }

    public void AttackHitEvent() // Animation event
    {
        if (target == null) return;
        target.TakeDamage(damage);
        target.GetComponent<DisplayDamage>().showBloodImpact();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    EnemyHealth enemyHealth;
    Transform target; // player
    [SerializeField] float chaseRange = 5f;
    NavMeshAgent navMeshAgent; // enemy itself
    float distToTarget = Mathf.Infinity;
    bool isProvoked = false;
    [SerializeField] float turnSpeed = 3f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<PlayerHealth>().transform;
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if (enemyHealth.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }

        distToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distToTarget <= chaseRange)
        {
            isProvoked = true;
        }
        if (distToTarget > chaseRange && isProvoked)
        {
            isProvoked = false;
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        faceTarget();

        if (distToTarget >= navMeshAgent.stoppingDistance)
        {
            chaseTar();
        }
        else if(distToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTar();
        }
    }

    private void AttackTar()
    {
        GetComponent<Animator>().SetBool("Attack", true);
    }

    private void chaseTar()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
    }

    private void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized; //magnitude=1 same vector
        Quaternion LookAt = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, LookAt, Time.deltaTime * turnSpeed);
                                        // Spherical interpolation
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}

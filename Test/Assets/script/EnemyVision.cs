using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyVision : MonoBehaviour
{
    public float viewRadius;
    public float viewAngle;

    public LayerMask targetPlayer;
    public LayerMask obsatcleMask;

    private NavMeshAgent _enemy;
    Animator animator;
    public GameObject Player;
    void Start()
    {
        animator = GetComponent<Animator>();
        _enemy = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector3 playerTarget = (Player.transform.position - transform.position).normalized;
        animator.SetBool("isWalking", true);
        if (Vector3.Angle(transform.forward, playerTarget) < viewAngle / 2)
        {
            float distanceToTarget = Vector3.Distance(transform.position, Player.transform.position);
            if (distanceToTarget <= viewRadius)
            {
                if (Physics.Raycast(transform.position, playerTarget, distanceToTarget, obsatcleMask) == false)
                {
                    _enemy.SetDestination(Player.transform.position);
                }
            }
        }
    }
}

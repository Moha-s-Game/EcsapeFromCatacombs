using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent _enemy;


    public Transform PlayerTarget;
    // Start is called before the first frame update
    void Start()
    {
        _enemy = GetComponent<NavMeshAgent>();  
    }

    // Update is called once per frame
    void Update()
    {
        _enemy.SetDestination(PlayerTarget.position);
    }
}

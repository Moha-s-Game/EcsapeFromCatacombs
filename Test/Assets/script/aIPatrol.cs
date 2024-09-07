using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class aIPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    int current;
    public float speed;
    void Start()
    {
        current = 0;
    }

    void Update()
    {
        if(transform.position != waypoints[current].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].position, speed * Time.deltaTime);
        }
        else
        {
            current = (current + 1) % waypoints.Length;
        }
    }
    
}

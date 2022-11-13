using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    private FieldOfView fov;
    private NavMeshAgent agent;

    public void Awake()
    {
        fov = GetComponent<FieldOfView>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (fov.canSeePlayer) 
            agent.SetDestination(fov.playerRef.transform.position);
    }
}

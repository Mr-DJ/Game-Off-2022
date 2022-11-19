using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AngelBehaviour : MonoBehaviour
{
    public GameObject player;
    
    public bool freeze;

    private FieldOfView fov;
    private NavMeshAgent agent;
    private SpriteRenderer spr;
    private Rigidbody rb;
    private Animator animator;

    public void Awake()
    {
        fov = GetComponent<FieldOfView>();
        agent = GetComponent<NavMeshAgent>();
        spr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        agent.updateRotation = false;
    }

    void FixedUpdate()
    {   
        if (Mathf.Abs(agent.velocity.x) > 0)
            spr.flipX = agent.velocity.x < 0;

        bool chase = fov.visibleTargets.Contains(player) && !freeze;
        
        animator.SetBool("chase", chase);
        agent.isStopped = !chase;
        
        if (chase) 
            agent.SetDestination(fov.playerRef.transform.position);
    }
}

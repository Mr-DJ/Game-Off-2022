using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AngelBehaviour : MonoBehaviour
{
    public GameObject player;
    
    public bool freeze;
    public bool chase;

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

    void Update()
    {   
        if (Mathf.Abs(agent.velocity.x) > 0)
            spr.flipX = agent.velocity.x < 0;

        chase = fov.visibleTargets.Contains(player) && !freeze;
        
        animator.SetBool("chase", chase);

        if (chase) 
        {
            agent.SetDestination(fov.playerRef.transform.position);
            StartCoroutine(ChaseRoutine());
        }
    }

    private IEnumerator ChaseRoutine()
    {
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("chase"));
        agent.isStopped = !chase;
    }
}

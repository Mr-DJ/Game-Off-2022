using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour 
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;
    
}
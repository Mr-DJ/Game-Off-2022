using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject follow;

    public float range;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(follow.GetComponent<Rigidbody>().velocity - rb.velocity, ForceMode.VelocityChange);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject follow;
    public Speed speed;

    public float distance = 3f;
    public float acceleration = 20f;

    public Speed followSpeed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        followSpeed = follow.GetComponent<PlayerMovementController>().speed;
        speed.maximum = followSpeed.maximum + 5f;
        speed.minimum = followSpeed.minimum;
    }

    void FixedUpdate()
    {
        float xgap = follow.transform.position.x - this.transform.position.x;
        Vector3 velocity = follow.GetComponent<Rigidbody>().velocity;
        speed.current = Mathf.Max(
            speed.minimum, 
            Mathf.Min(velocity.x + acceleration * Time.deltaTime * ((xgap > distance) ? 1 : 0), speed.maximum)
        );
        rb.velocity = new Vector3(speed.current, rb.velocity.y, rb.velocity.z);
    }
}

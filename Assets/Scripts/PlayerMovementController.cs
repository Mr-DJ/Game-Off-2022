using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine;

[Serializable]
public class GroundCheckConstraints
{
    public float radius;
    public float offset;
    public bool grounded;

    public LayerMask groundLayer;
}

public class PlayerMovementController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float turnSpeed = 3;
    public float maxLeaning = 45;
    public float gravityScale;

    public GroundCheckConstraints groundCheck;

    private Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        float haxis = Input.GetAxis("Horizontal");
        float vaxis = Input.GetAxis("Vertical");
        
        rb.velocity = new Vector3(moveSpeed, rb.velocity.y, vaxis * turnSpeed);
        transform.rotation = Quaternion.Euler(vaxis * maxLeaning, 0, 0);

        bool grounded = Physics.CheckSphere(
            transform.position - transform.up * groundCheck.offset, groundCheck.radius, groundCheck.groundLayer
        );
        
        // Apply custom gravity scale when airbone to ground the player faster
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
    }

    void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position - transform.up * groundCheck.offset, groundCheck.radius);
    }
}
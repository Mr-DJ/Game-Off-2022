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
    public float speed = 3;
    public float jumpForce = 5;
    public float gravityScale;

    public GroundCheckConstraints groundCheck;

    private Rigidbody rb;
    private SpriteRenderer spr;
    private Animator animator;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        spr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void FixedUpdate()
    {
        float haxis = Input.GetAxis("Horizontal");
        float vaxis = Input.GetAxis("Vertical");
        
        bool walking = Mathf.Abs(haxis) + Mathf.Abs(vaxis) > 0;
        animator.SetBool("walking", walking);

        if (walking) 
        {
            // rb.MoveRotation(Quaternion.Euler(0, Mathf.Rad2Deg * Mathf.Atan2(haxis, vaxis), 0));
            spr.flipX = haxis < 0;
            rb.velocity = new Vector3(haxis * speed, rb.velocity.y, vaxis * speed);
        }

        bool grounded = Physics.CheckSphere(
            transform.position - transform.up * groundCheck.offset, groundCheck.radius, groundCheck.groundLayer
        );
        
        // Apply custom gravity scale when airbone to ground the player faster
        if (!grounded)
            rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);

        if (Input.GetButtonDown("Jump") && grounded) 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position - transform.up * groundCheck.offset, groundCheck.radius);
    }
}
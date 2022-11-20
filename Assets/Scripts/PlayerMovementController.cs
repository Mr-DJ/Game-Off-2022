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

[Serializable]
public class Speed 
{
    public float current;
    public float maximum;
    public float minimum;
    public float turning;
    public float acceleration;
}

public class PlayerMovementController : MonoBehaviour
{
    public Speed speed;

    public GroundCheckConstraints groundCheck;
    public float maxLeaning = 30;
    public float gravityScale;

    private Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        float haxis = Input.GetAxis("Horizontal");
        float vaxis = Input.GetAxis("Vertical");

        speed.current = Mathf.Min(speed.maximum, Mathf.Max(haxis * Time.deltaTime * speed.acceleration + speed.current, speed.minimum));
        
        rb.velocity = new Vector3(speed.current, rb.velocity.y, vaxis * speed.turning);
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
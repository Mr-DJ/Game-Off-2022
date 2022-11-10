using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float speed = 1;
    public float jumpForce = 2;

    private Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float haxis = Input.GetAxis("Horizontal");
        float vaxis = Input.GetAxis("Vertical");
        
        if (Mathf.Abs(haxis) + Mathf.Abs(vaxis) > 0) 
        {
            rb.MoveRotation(Quaternion.Euler(0, Mathf.Rad2Deg * Mathf.Atan2(haxis, vaxis), 0));
            rb.velocity = new Vector3(haxis, 0, vaxis).normalized * speed * Time.fixedDeltaTime;
        }
    }
}

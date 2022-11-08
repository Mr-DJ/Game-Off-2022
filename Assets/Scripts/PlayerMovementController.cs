using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float speed = 5;

    void Update()
    {
        float haxis = Input.GetAxis("Horizontal");
        float vaxis = Input.GetAxis("Vertical");
        
        if (Mathf.Abs(haxis) + Mathf.Abs(vaxis) > 0) 
        {
            this.transform.rotation = Quaternion.Euler(0, Mathf.Rad2Deg * Mathf.Atan2(haxis, vaxis), 0);

            haxis = Mathf.Abs(haxis);
            vaxis = Mathf.Abs(vaxis);
            this.transform.Translate(Time.deltaTime * speed * Mathf.Max(haxis, vaxis)  * Vector3.forward);
        }
    }
}

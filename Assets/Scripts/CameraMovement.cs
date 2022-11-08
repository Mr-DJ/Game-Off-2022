using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject follow;
    public Vector3 offset = new Vector3(0f, 1f, -5f);

    public float smoothTime = .3f;
    public bool trackXAxis = true;
    public bool trackYAxis = true;
    public bool trackZAxis = true;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        Vector3 followVec = this.follow.transform.position + offset; 
        Vector3 destination = new Vector3(
            (trackXAxis) ? followVec.x : this.transform.position.x,
            (trackYAxis) ? followVec.y : this.transform.position.y,
            (trackZAxis) ? followVec.z : this.transform.position.z
        );

        this.transform.position = Vector3.SmoothDamp(
            this.transform.position, destination, ref velocity, smoothTime
        );
    }
}

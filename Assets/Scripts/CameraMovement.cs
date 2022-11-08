using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject follow;
    public Vector3 offset = new Vector3(10, 2, 0);

    public float speed = .025f;
    public bool trackXAxis = false;
    public bool trackYAxis = false;
    public bool trackZAxis = true;

    void Update()
    {
        Vector3 followVec = this.follow.transform.position + offset; 
        Vector3 destination = new Vector3(
            (trackXAxis) ? followVec.x : this.transform.position.x,
            (trackYAxis) ? followVec.y : this.transform.position.y,
            (trackZAxis) ? followVec.z : this.transform.position.z
        ); 

        // Since the distance will keep shortening with each frame, the interpolator will eventually 
        // slow down as it approaches its destination.
        this.transform.position = Vector3.Lerp(
            this.transform.position,
            destination,
            speed
        );
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform target; // The GameObject the camera will follow
    public Vector3 offset;   // Offset from the target position

    void LateUpdate()
    {
        // Check if the target is assigned
        if (target != null)
        {
            // Set the camera's position to the target position plus the offset
            transform.position = target.position + offset;
        }
    }
}

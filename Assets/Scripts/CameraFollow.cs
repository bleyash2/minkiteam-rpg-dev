using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 cameraOffset;
    public float smoothingSpeed = 0.125f;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothingSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}

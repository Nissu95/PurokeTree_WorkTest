using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform minCameraPos;
    [SerializeField] Transform maxCameraPos;
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;

    void FixedUpdate()
    {
        transform.position = target.position + offset;
    }
}

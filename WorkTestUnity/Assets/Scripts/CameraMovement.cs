using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float minCameraPos;
    [SerializeField] float maxCameraPos;
    [SerializeField] float followSpeed;
    [SerializeField] Vector3 offset;

    Vector3 velocity = Vector3.zero;

    Vector3 targetPos;
    Vector3 smoothPos;

    void FixedUpdate()
    {
        targetPos = target.position + offset;
        targetPos.x = Mathf.Clamp(targetPos.x, minCameraPos, maxCameraPos);
        smoothPos = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, followSpeed * Time.fixedDeltaTime);

        transform.position = smoothPos;
    }
}

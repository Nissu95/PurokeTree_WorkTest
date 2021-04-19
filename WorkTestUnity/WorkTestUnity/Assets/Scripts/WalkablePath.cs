using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkablePath : MonoBehaviour
{
    [SerializeField] float maxX;
    [SerializeField] float minX;

    Vector2 charPos = Vector2.zero;
    CharacterController2D cc2D;

    void Start()
    {
        cc2D = GetComponent<CharacterController2D>();
        charPos = transform.position;
    }

    void FixedUpdate()
    {
        if (transform.position.x > maxX)
        {
            charPos.x = maxX;
            transform.position = charPos;
            cc2D.SetCurrentSpeed(0);
        }
        else if (transform.position.x < minX)
        {
            charPos.x = minX;
            transform.position = charPos;
            cc2D.SetCurrentSpeed(0);
        }
    }
}

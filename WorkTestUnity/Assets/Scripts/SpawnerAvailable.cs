﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAvailable : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    bool available = true;

    RaycastHit2D hit2D;

    void FixedUpdate()
    {
        hit2D = Physics2D.Raycast(transform.position, Vector2.up, 2.0f, layerMask);

        if (hit2D.collider != null)
        {
            if (hit2D.transform.tag == "Player")
                available = false;
        }
        else
            available = true;
    }

    public bool GetAvailable()
    {
        return available;
    }

}

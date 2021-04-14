using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    RaycastHit2D hit2D;

    void FixedUpdate()
    {
        hit2D = Physics2D.Raycast(transform.position, Vector2.up, 2.0f, layerMask);

        if (hit2D.collider != null)
            if (hit2D.transform.tag == "Player")
                PickUpCoins();
    }

    void PickUpCoins()
    {
        GameManager.instance.AddCoins(1);
        GetComponent<PoolObject>().Recycle();
    }
}

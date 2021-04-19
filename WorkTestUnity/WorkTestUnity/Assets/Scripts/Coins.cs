using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    RaycastHit2D hit2D;
    Timer timer = new Timer();

    void Start()
    {
        timer.SetTime(GameManager.instance.GetCoinDisappearTime());
    }

    void FixedUpdate()
    {
        timer.Update();
        hit2D = Physics2D.Raycast(transform.position, Vector2.up, 2.0f, layerMask);

        if (hit2D.collider != null)
            if (hit2D.transform.tag == "Player")
                PickUpCoins();

        if (timer.TimeUp())
        {
            timer.Reset();
            GetComponent<PoolObject>().Recycle();
        }
    }

    void PickUpCoins()
    {
        GameManager.instance.AddCoins(1);
        timer.Reset();
        GetComponent<PoolObject>().Recycle();
    }
}

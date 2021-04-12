using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField] float minAngle;
    [SerializeField] float maxAngle;

    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;

    [SerializeField] float minTime;
    [SerializeField] float maxTime;

    Pool pool;
    Timer timer = new Timer();

    /*Random.Range(minAngle, maxAngle);
       Random.Range(minSpeed, maxSpeed);*/

    void Start()
    {
        pool = PoolManager.GetInstance().GetPool("RockPool");
        timer.SetTime(Random.Range(minTime, maxTime));
    }

    void FixedUpdate()
    {
        timer.Update();

        if (timer.TimeUp())
        {
            PoolObject po = pool.GetPooledObject();
            po.gameObject.transform.position = transform.position;
            timer.SetTime(Random.Range(minTime, maxTime));
        }
    }
}

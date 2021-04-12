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
            po.transform.Rotate(0, 0, Random.Range(minAngle, maxAngle));
            po.gameObject.GetComponent<PhysicsScript>().AddForceX(Random.Range(minSpeed, maxSpeed));
            timer.SetTime(Random.Range(minTime, maxTime));
        }
    }
}

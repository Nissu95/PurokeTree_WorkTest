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

    private Pool pool;

    void Start()
    {
        pool = PoolManager.GetInstance().GetPool("RockPool");
    }

    void FixedUpdate()
    {
        /*Random.Range(minAngle, maxAngle);
        Random.Range(minSpeed, maxSpeed);
        Random.Range(minTime, maxTime);*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PoolObject po = pool.GetPooledObject();
            po.gameObject.transform.position = transform.position;
        }
    }
}

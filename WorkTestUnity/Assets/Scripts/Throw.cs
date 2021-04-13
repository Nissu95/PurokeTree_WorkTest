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
    float angle;
    float speed;

    void Start()
    {
        pool = PoolManager.GetInstance().GetPool("RockPool");
        timer.SetTime(Random.Range(minTime, maxTime));
        angle = Random.Range(minAngle, maxAngle);
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void FixedUpdate()
    {
        timer.Update();

        if (timer.TimeUp())
        {
            PoolObject po = pool.GetPooledObject();
            po.gameObject.transform.position = transform.position;
            po.gameObject.transform.Rotate(0, 0, angle);
            po.gameObject.GetComponent<PhysicsScript>().AddForce(transform.right * speed);
            //po.gameObject.GetComponent<PhysicsScript>().AddForce(Mathf.Cos(angle) * speed, Mathf.Sin(angle) * speed);
            timer.SetTime(Random.Range(minTime, maxTime));
            angle = Random.Range(minAngle, maxAngle);
            speed = Random.Range(minSpeed, maxSpeed);
        }
    }
}

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

    [SerializeField] bool isRockInstantiate;

    Timer timer = new Timer();
    Pool pool;
    Animator animator;
    float angle;
    float speed;

    void Start()
    {
        pool = PoolManager.GetInstance().GetPool("RockPool");
        timer.SetTime(Random.Range(minTime, maxTime));
        animator = GetComponentInParent<Animator>();
    }

    void Update()
    {
        timer.Update();
        if (timer.TimeUp())
        {
            timer.SetTime(Random.Range(minTime, maxTime));
            angle = Random.Range(minAngle, maxAngle);
            speed = Random.Range(minSpeed, maxSpeed);
            animator.SetTrigger("Throw");
        }
        InstantiateRock();
    }

    public void InstantiateRock()
    {
        if (isRockInstantiate)
        {
            PoolObject po = pool.GetPooledObject();
            po.gameObject.transform.position = transform.position;
            RockScript rc = po.gameObject.GetComponent<RockScript>();
            rc.AddForce(Mathf.Cos(angle * Mathf.Deg2Rad) * speed, Mathf.Sin(angle * Mathf.Deg2Rad) * speed);
            rc.SetSpeed(speed);
        }
    }
}

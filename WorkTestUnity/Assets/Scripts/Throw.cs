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
        /*angle = Random.Range(minAngle, maxAngle);
        speed = Random.Range(minSpeed, maxSpeed);*/
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
            po.gameObject.transform.Rotate(0, 0, angle);
            po.gameObject.GetComponent<RockScript>().SetVelocity(po.gameObject.transform.right * speed);
            //po.gameObject.GetComponent<RockScript>().AddForceX(po.gameObject.transform.right.x * speed);
            //po.gameObject.GetComponent<RockScript>().AddForce(Mathf.Cos(angle) * speed, Mathf.Sin(angle) * speed);
        }
    }
}

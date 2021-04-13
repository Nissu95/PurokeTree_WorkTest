using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] float gravity;
    [SerializeField] float deceleration;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    public float GetGravity()
    {
        return gravity;
    }

    public float GetDeceleration()
    {
        return deceleration;
    }

}

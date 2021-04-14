using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] float gravity;
    [SerializeField] float deceleration;
    [SerializeField] int rockAmountCoinAppear;
    [SerializeField] float coinDisappearTime;

    int rockAmount = 0;
    int coins = 0;

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

    public int GetRockAmount()
    {
        return rockAmount;
    }

    public void AddRockAmount(int amount)
    {
        rockAmount += amount;
    }

    public int GetRockAmountCoinAppear()
    {
        return rockAmountCoinAppear;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            rockAmount += 1;
        }
    }

    public void AddCoins(int _coins)
    {
        coins += _coins;
    }

    public float GetCoinDisappearTime()
    {
        return coinDisappearTime;
    }
}

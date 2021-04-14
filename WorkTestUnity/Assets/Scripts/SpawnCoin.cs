using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [SerializeField] GameObject coin;

    List<SpawnerAvailable> spawnerAvailables = new List<SpawnerAvailable>();

    int lastRockAmount = 0;

    void Awake()
    {
        InitializeList();
    }

    void FixedUpdate()
    {
        if (GameManager.instance.GetRockAmount() != lastRockAmount &&
            GameManager.instance.GetRockAmount() % GameManager.instance.GetRockAmountCoinAppear() == 0)
        {
            CheckList();
            int aux = Random.Range(0, spawnerAvailables.Count);
            Instantiate(coin, spawnerAvailables[aux].transform);
            lastRockAmount = GameManager.instance.GetRockAmount();
            InitializeList();
        }
    }

    void InitializeList()
    {
        SpawnerAvailable[] aux = GetComponentsInChildren<SpawnerAvailable>();

        if (spawnerAvailables.Count > 0)
            spawnerAvailables.Clear();

        for (int i = 0; i < aux.Length; i++)
            spawnerAvailables.Add(aux[i]);
    }

    void CheckList()
    {
        for (int i = 0; i < spawnerAvailables.Count; i++)
        {
            if (!spawnerAvailables[i].GetAvailable())
                spawnerAvailables.Remove(spawnerAvailables[i]);
        }
    }

}

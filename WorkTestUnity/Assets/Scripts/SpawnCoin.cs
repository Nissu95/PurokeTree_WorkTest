using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    List<SpawnerAvailable> spawnerAvailables = new List<SpawnerAvailable>();

    Pool pool;
    int lastRockAmount = 0;

    void Start()
    {
        InitializeList();
        pool = PoolManager.GetInstance().GetPool("CoinsPool");
    }

    void FixedUpdate()
    {
        if (GameManager.instance.GetRockAmount() != lastRockAmount &&
            GameManager.instance.GetRockAmount() % GameManager.instance.GetRockAmountCoinAppear() == 0)
        {
            CheckList();
            int aux = Random.Range(0, spawnerAvailables.Count);

            PoolObject po = pool.GetPooledObject();
            po.gameObject.transform.position = spawnerAvailables[aux].transform.position;

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

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
    [SerializeField] GameObject locationGuideGO;
    [SerializeField] Transform floorTrans;
    [SerializeField] Transform goalTrans;

    List<LocationGuide> lLocationGuides = new List<LocationGuide>();

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            rockAmount += 1;
        }

        LocalizationGuide();
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

    public void AddCoins(int _coins)
    {
        coins += _coins;
    }

    public float GetCoinDisappearTime()
    {
        return coinDisappearTime;
    }

    public float GetFloorY()
    {
        return floorTrans.position.y;
    }

    public Transform GetGoalTrans()
    {
        return goalTrans;
    }

    //--------------------------------------------------------------------
    //Location Guide Functions
    //--------------------------------------------------------------------

    public GameObject GetLocationGuideGO()
    {
        return locationGuideGO;
    }

    void LocalizationGuide()
    {
        LocationGuide[] aAux = FindObjectsOfType<LocationGuide>();
        float fAux = Mathf.Infinity;
        int iAux = 0;

        if (lLocationGuides.Count > 0)
            lLocationGuides.Clear();

        for (int i = 0; i < aAux.Length; i++)
            if (aAux[i].GetIsVisible())
                lLocationGuides.Add(aAux[i]);

        for (int i = 0; i < lLocationGuides.Count; i++)
        {
            float aux = lLocationGuides[i].CalculateDistanceToFloor();
            if (aux < fAux)
            {
                fAux = aux;
                iAux = i;
            }
        }

        if (lLocationGuides.Count > 0 && lLocationGuides[iAux] != null)
            lLocationGuides[iAux].SetLocationGuide();

    }
    //--------------------------------------------------------------------
}

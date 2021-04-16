using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] Text rockAmountTxt;
    [SerializeField] Text coinAmountTxt;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    void Start()
    {
        RockAmountUIUpdate();
        CoinAmountUIUpdate();
    }

    public void RockAmountUIUpdate()
    {
        rockAmountTxt.text = "x " + GameManager.instance.GetRockAmount();
    }

    public void CoinAmountUIUpdate()
    {
        coinAmountTxt.text = "x " + GameManager.instance.GetCoins();
    }

}

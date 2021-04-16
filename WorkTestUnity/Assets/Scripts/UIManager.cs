using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] GameObject game;
    [SerializeField] GameObject rockAmountUI;
    [SerializeField] GameObject coinAmountUI;

    Text rockAmountTxt;
    Text coinAmountTxt;

    void Awake()
    {
        //DontDestroyOnLoad(this);
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    void Start()
    {
        if (game)
        {
            rockAmountTxt = rockAmountUI.GetComponentInChildren<Text>();
            coinAmountTxt = coinAmountUI.GetComponentInChildren<Text>();
            RockAmountUIUpdate();
            CoinAmountUIUpdate();
            SetActiveGame(true);
        }
    }

    public void RockAmountUIUpdate()
    {
        rockAmountTxt.text = "x " + GameManager.instance.GetRockAmount();
    }

    public void CoinAmountUIUpdate()
    {
        coinAmountTxt.text = "x " + GameManager.instance.GetCoins();
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }

    void SetActiveGame(bool active)
    {
        game.SetActive(active);
        rockAmountUI.SetActive(active);
        coinAmountUI.SetActive(active);
    }
}

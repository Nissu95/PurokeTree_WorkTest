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
    [SerializeField] GameObject afterGameMenu;
    [SerializeField] Text rockAmountDisplay;
    [SerializeField] Text coinsAmountDisplay;
    [SerializeField] Text timeTxt;

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

    void FixedUpdate()
    {
        if (timeTxt && timeTxt.gameObject.activeInHierarchy)
            timeTxt.text = "Time:\n" + GameManager.instance.GetTime();
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

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SetActiveGame(bool active)
    {
        rockAmountUI.SetActive(active);
        coinAmountUI.SetActive(active);
        timeTxt.gameObject.SetActive(active);
        game.SetActive(active);SetActiveAfterMenu(!active);
    }

    void SetActiveAfterMenu(bool active)
    {
        afterGameMenu.SetActive(active);

        if (active)
        {
            rockAmountDisplay.text = rockAmountTxt.text;
            coinsAmountDisplay.text = coinAmountTxt.text;
        }
    }
}

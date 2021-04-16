using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] Text rockAmountTxt;

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
    }

    public void RockAmountUIUpdate()
    {
        rockAmountTxt.text = "x " + GameManager.instance.GetRockAmount();
    }
}

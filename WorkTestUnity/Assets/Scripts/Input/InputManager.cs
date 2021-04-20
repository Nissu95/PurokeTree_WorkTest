using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    GeneralInput input;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;

#if UNITY_IOS || UNITY_ANDROID
        input = new MobileInput();
#elif UNITY_STANDALONE_WIN
        input = new PCInput();
#endif
    }

    void FixedUpdate()
    {
        input.Update();
    }

    public GeneralInput GetInput()
    {
        return input;
    }
}

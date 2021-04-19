using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBoxScript : MonoBehaviour
{
    [SerializeField] float verticalBounceFactor;
    [SerializeField] float horizontalBounceFactor;

    public float GetVerticalBounceFactor()
    {
        return verticalBounceFactor;
    }

    public float GetHorizontalBounceFactor()
    {
        return horizontalBounceFactor;
    }

}

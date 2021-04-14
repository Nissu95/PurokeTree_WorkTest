using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationGuide : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    RaycastHit2D hit2DUp;
    GameObject locationGuide;

    float floorY;
    bool isOnFloor = false;

    void Start()
    {
        locationGuide = GameManager.instance.GetLocationGuideGO();
        floorY = GameManager.instance.GetFloorY();
    }

    void OnEnable()
    {
        isOnFloor = false;
    }

    public void SetLocationGuide()
    {
        hit2DUp = Physics2D.Raycast(transform.position, -transform.up, Mathf.Infinity, layerMask);

        if (hit2DUp.collider != null)
        {
            if (hit2DUp.transform.tag == "Floor" && locationGuide != null)
            {
                locationGuide.transform.position = hit2DUp.point;
                locationGuide.SetActive(true);
            }
        }
    }

    public float CalculateDistanceToFloor()
    {
        return transform.position.y - floorY;
    }

    public void SetFloorY(float _FloorY)
    {
        floorY = _FloorY;
    }

    public void SetIsOnFloor(bool _IsOnFloor)
    {
        isOnFloor = _IsOnFloor;
    }

    public bool GetIsOnFloor()
    {
        return isOnFloor;
    }
}

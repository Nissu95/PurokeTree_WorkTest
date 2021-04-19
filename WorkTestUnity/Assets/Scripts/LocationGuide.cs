using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationGuide : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    RaycastHit2D hit2DUp;
    GameObject locationGuide;
    RockScript rc;
    float floorY;
    bool isVisible = true;

    void Start()
    {
        locationGuide = GameManager.instance.GetLocationGuideGO();
        floorY = GameManager.instance.GetFloorY();
        rc = GetComponent<RockScript>();
    }

    void OnEnable()
    {
        isVisible = true;
    }

    void FixedUpdate()
    {
        hit2DUp = Physics2D.Raycast(transform.position, -transform.up, Mathf.Infinity, layerMask);
        Debug.DrawRay(transform.position, -transform.up, Color.red, Mathf.Infinity);
        if (hit2DUp.collider != null)
        {
            if (hit2DUp.transform.tag == "Finish")
            {
                isVisible = false;
                rc.IsLastBounce(true);
            }
        }
    }

    public void SetLocationGuide()
    {
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

    public void SetIsVisible(bool _IsVisible)
    {
        isVisible = _IsVisible;
    }

    public bool GetIsVisible()
    {
        return isVisible;
    }

    public void Deactivate()
    {
        locationGuide.SetActive(false);
    }

}

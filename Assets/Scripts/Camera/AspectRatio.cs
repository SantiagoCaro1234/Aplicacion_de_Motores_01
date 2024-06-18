using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatio : MonoBehaviour
{
    /*
     * aspect value in comparison to aspect ratio of user
        4:3 = 1.333333333333333
        16:9 = 1.777777777777778
        16:10 = 1.6
        21:9 = 2.333333333333333
    */

    [SerializeField] public float aspect;
    public AspectRatioValue _AspectRatioName;

    private float fourThirdsValue = 1.333333333333333f;
    private float sixteenNinthsValue = 1.777777777777778f;
    private float sixteenTenthsValue = 1.6f;
    private float twentyNinthsValue = 2.333333333333333f;

    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        SetAspect(_AspectRatioName);  // Update aspect ratio
        cam.aspect = aspect;  // Update camera aspect ratio
    }

    public enum AspectRatioValue
    {
        FourThirds,
        SixteenNinths,
        SixteenTenths,
        TwentyNinths
    }

    public void SetAspect(AspectRatioValue ratioValue)
    {
        switch (ratioValue)
        {
            case AspectRatioValue.FourThirds:
                aspect = fourThirdsValue;
                break;
            case AspectRatioValue.SixteenNinths:
                aspect = sixteenNinthsValue;
                break;
            case AspectRatioValue.SixteenTenths:
                aspect = sixteenTenthsValue;
                break;
            case AspectRatioValue.TwentyNinths:
                aspect = twentyNinthsValue;
                break;
        }
    }
}
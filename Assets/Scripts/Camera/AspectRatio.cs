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
        cam.aspect = aspect;
    }

    public AspectRatioValue _AspectRatioName;

    public enum AspectRatioValue
    {
        FourThirds,
        sixteenNinths,
        sixteenTenths,
        twentyNinths
    }

    //public void SetAspect(Enum ratioValue)
    //{
    //    switch (ratioValue)
    //    {
    //        case ratioValue.FourThirds:
    //            aspect = fourThirdsValue;
    //            break;
    //        case ratioValue.sixteenNinths:
    //            aspect = sixteenNinthsValue;
    //            break;
    //        case ratioValue.sixteenTenths:
    //            aspect = sixteenTenthsValue;
    //            break;
    //        case ratioValue.twentyNinths:
    //            aspect = twentyNinthsValue;
    //            break;
    //    }
    //}
}
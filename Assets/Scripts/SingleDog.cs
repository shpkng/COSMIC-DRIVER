/*
 * File: SingleDog.cs
 * Project: Scripts
 * File Created: Thursday, 7th June 2018 4:32:54 am
 * Author: shpkng (shpkng@gmail.com)
 * -----
 * Last Modified: Thursday, 7th June 2018 5:05:57 am
 * Modified By: shpkng (shpkng@gmail.com>)
 * -----
 * loving the lovely sunshine in autumn.♥
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This Single-Dog script mainly takes care of the two parts of each one obstacle
public class SingleDog : MonoBehaviour
{
    #region Variables
    public enum 颜色_Color
    {
        红色_Red,
        蓝色_Blue
    };

    public Obstacle obstacle;

    public int perfect = 100;
    public int good = 80;
    public int ok = 60;

    public int divisor = 50;

    public bool withMid = false;
    public bool _in = false;
    [HideInInspector]public bool unused = true;

    public bool isLong = false;

    public 颜色_Color _颜色_Color;

    #endregion

    //我们把长Ob的计分放在了SingleDog脚本中
    void FixedUpdate()
    {
        //Debug.Log("" + withMid + "  " + _in);
        if (isLong)
        {
            CheckOutLong();
        }

        else if(unused)
            CheckOut();
    }

    //结算分数
    void CheckOut()
    {

        if (withMid && !_in) //整体在内
        {
            obstacle.SumPoints(perfect, 2, _颜色_Color.GetHashCode());
            unused = false;
        }
        else if (withMid && _in)
        {
            obstacle.SumPoints(good, 1, _颜色_Color.GetHashCode());
            unused = false;
        }
        else if (_in)
        {
            obstacle.SumPoints(ok, 0, _颜色_Color.GetHashCode());
            unused = false;
        }

    }

    void CheckOutLong()
    {
        if (withMid && !_in) //整体在内
        {
            obstacle.SumLong(perfect / divisor, 2, _颜色_Color.GetHashCode());
        }
        else if (withMid && _in)
        {
            obstacle.SumLong(good / divisor, 1, _颜色_Color.GetHashCode());
        }
        else if (_in)
        {
            obstacle.SumLong(ok / divisor, 0, _颜色_Color.GetHashCode());
        }
    }

    // To determine the points value
    // void OnTriggerEnter(Collider other)
    // {
    //     Debug.Log(other.tag);

    //     if (other.tag == "ControllerMid" && other.GetComponent<CColor>().color.GetHashCode() == _颜色_Color.GetHashCode())   //触及圆心判定点
    //     {
    //         withMid = true;
    //     }

    //     if (other.tag == "Controller" && other.GetComponent<CColor>().color.GetHashCode() == _颜色_Color.GetHashCode())  //至少部分在内
    //     {
    //         _in = true;
    //     }


    //     if (!isLong)
    //         CheckOut();

    // }

    // void OnTriggerExit(Collider other)
    // {
    //     if (other.tag == "ControllerMid")
    //     {
    //         withMid = false;
    //     }
    //     if (other.tag == "Controller")
    //     {
    //         _in = false;
    //     }
    // }
}
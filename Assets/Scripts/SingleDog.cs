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
    public enum 颜色_Color
    {
        红色_Red,
        蓝色_Blue
    };

    public Obstacle obstacle;

    [SerializeField] int perfect = 100;
    [SerializeField] int good = 80;
    [SerializeField] int ok = 60;

    [SerializeField] bool withMid = false;
    [SerializeField] bool _in = false;

    [SerializeField] 颜色_Color _颜色_Color;

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "ControllerMid" && other.GetComponent<CColor>().color.GetHashCode() == _颜色_Color.GetHashCode())   //触及圆心判定点
        {
            withMid = true;
        }

        if (other.tag == "Controller" && other.GetComponent<CColor>().color.GetHashCode() == _颜色_Color.GetHashCode())  //至少部分在内
        {
            _in = true;
        }

        if (withMid && !_in) //整体在内
        {
            obstacle.SumPoints(perfect,2,_颜色_Color.GetHashCode());
        }
        else if (withMid && _in)
        {
            obstacle.SumPoints(good,1,_颜色_Color.GetHashCode());
        }
        else if (_in)
        {
            obstacle.SumPoints(ok,0,_颜色_Color.GetHashCode());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "ControllerMid")
        {
            withMid = false;
        }
        if (other.tag == "Controller")
        {
            _in = false;
        }
    }
}
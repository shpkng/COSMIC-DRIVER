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

    [SerializeField] 颜色_Color _颜色_Color;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Controller" && other.GetComponent<CColor>().color == _颜色_Color)
        {
            obstacle.SumPoints(0);
        }

        // if(other.tag == "ControllerMid")
        // {

        // }
    }

    void OnTriggerExit(Collider other)
    {

    }
}
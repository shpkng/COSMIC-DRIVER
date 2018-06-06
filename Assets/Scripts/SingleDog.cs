/*
 * File: SingleDog.cs
 * Project: Script
 * File Created: Friday, 1st June 2018 2:19:04 am
 * Author: shpkng (shpkng@gmail.com)
 * -----
 * Last Modified: Wednesday, 6th June 2018 4:00:53 am
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
        if (other.tag == "Controller")
        {
            //播放消失动画/特效
            obstacle.SumPoints(0);
        }
    }
}
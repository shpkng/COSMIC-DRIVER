﻿/*
 * File: CColor.cs
 * Project: Scripts
 * File Created: Thursday, 7th June 2018 4:59:14 am
 * Author: shpkng (shpkng@gmail.com)
 * -----
 * Last Modified: Thursday, 7th June 2018 5:06:05 am
 * Modified By: shpkng (shpkng@gmail.com>)
 * -----
 * loving the lovely sunshine in autumn.♥
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CColor : MonoBehaviour
{
    GameControl g;

    public SingleDog.颜色_Color color;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (color.GetHashCode() == other.GetComponent<SingleDog>()._颜色_Color.GetHashCode())
            other.GetComponent<SingleDog>()._in = true;
    }

    void OnTriggerExit(Collider other)
    {
        other.GetComponent<SingleDog>()._in = false;
    }

}

/*
 * File: autoHL.cs
 * Project: Script
 * File Created: Friday, 1st June 2018 12:08:01 am
 * Author: shpkng (shpkng@gmail.com)
 * -----
 * Last Modified: Wednesday, 6th June 2018 4:00:13 am
 * Modified By: shpkng (shpkng@gmail.com>)
 * -----
 * loving the lovely sunshine in autumn.♥
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(HighlightingSystem.Highlighter))]
public class AutoHL_Red : MonoBehaviour
{
    void Start()
    {
        GetComponent<HighlightingSystem.Highlighter>().ConstantOn(Color.red);
    }
}

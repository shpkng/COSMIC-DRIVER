/*
 * File: InOut.cs
 * Project: Script
 * File Created: Friday, 1st June 2018 12:30:26 am
 * Author: shpkng (shpkng@gmail.com)
 * -----
 * Last Modified: Wednesday, 6th June 2018 4:00:34 am
 * Modified By: shpkng (shpkng@gmail.com>)
 * -----
 * loving the lovely sunshine in autumn.♥
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOut : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            Debug.Log(1);
            //Fade-In
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            other.GetComponent<SingleDog>().obstacle.Exit();
        }

        Debug.Log(other.name);
    }
}

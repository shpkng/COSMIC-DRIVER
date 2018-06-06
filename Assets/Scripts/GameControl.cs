/*
 * File: GameControl.cs
 * Project: Script
 * File Created: Friday, 1st June 2018 3:16:03 am
 * Author: shpkng (shpkng@gmail.com)
 * -----
 * Last Modified: Wednesday, 6th June 2018 4:00:25 am
 * Modified By: shpkng (shpkng@gmail.com>)
 * -----
 * loving the lovely sunshine in autumn.♥
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GameControl takes the responsibility to count you points
public class GameControl : MonoBehaviour
{

    [SerializeField] UnityEngine.UI.Text point;

	int pointCache = 0;
    // Use this for initialization
    void Start()
    {
        point.text = "00000000";
    }

	public void AddPoints(int s)
	{
		pointCache += s;
		point.text = string.Format("{0:00000000}",pointCache);  //padding to 8 digits
	}

}

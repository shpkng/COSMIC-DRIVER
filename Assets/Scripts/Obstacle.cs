/*
 * File: Obstacle.cs
 * Project: Script
 * File Created: Sunday, 27th May 2018 9:20:08 pm
 * Author: shpkng (shpkng@gmail.com)
 * -----
 * Last Modified: Wednesday, 6th June 2018 4:00:44 am
 * Modified By: shpkng (shpkng@gmail.com>)
 * -----
 * loving the lovely sunshine in autumn.♥
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float opTimeNext;
    private float velocity;

    //Clockwhile 1 or reverse -1 or not 0
    private int rotationDir;

    //Describes how many singledog we need to trigger
    [SerializeField] private int 需要触发的数量_Needed = 2;
    [SerializeField] private bool isLong = false;

    //Triggered Single-Dog
    int singleCount = 0;

    [SerializeField] private SingleDog red;
    [SerializeField] private SingleDog blue;

    GameControl g;

    //temporary points sum.
    private int pSum = 0;

    void Start()
    {
        g = GameObject.Find("GameControl").GetComponent<GameControl>();
    }

    /// <summary>
    /// to assign values of these variables
    /// </summary>
    /// <param name="t">When the next obstacle will spawn</param>
    /// <param name="v">The velocity of this obstacle( it's only a float assigned to z-axis)</param>
    /// <param name="rot">Rotation of this one in EULER ANGLES</param>
    public void SetProperty(float t, float v, int rot)
    {
        opTimeNext = t;
        velocity = -v;
        transform.eulerAngles += new Vector3(0, 0, rot);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, velocity * Time.deltaTime);
    }

    /// <summary>
    /// This function is called to temporary store points for single "Single-Dog" and then sum up and show 'em to the Board UI.
    /// </summary>
    /// <param name="p"> Points of single "Single-Dog"</param>
    // public void SumPoints(int p, int lv)
    // {
    //     singleCount += 1;
    //     pSum += p;

    //     if (singleCount == 需要触发的数量_Needed)
    //     {
    //         g.AddPoints(pSum);
    //         g.ShowRing(lv);
    //         Destroy(this.gameObject);
    //     }
    // }


    public void SumPoints(int p, int lv, int color)
    {
        if (isLong)
        {
			
        }
        else
        {
            singleCount += 1;
            pSum += p;

            //__________________
            g.ShowRing(lv, color);
            //__________________

            if (singleCount == 需要触发的数量_Needed)
            {
                //__________________
                g.AddPoints(pSum);
                Destroy(this.gameObject);
            }
        }
    }

    /// <summary>
    /// Called when this whole obstacle hits the edge of FuncRange
    /// </summary>
    public void Exit()
    {
        //This if statement is actually useless since we've destroyed this gameobject if we succeeded
        if (singleCount != 2)
        {
            //Miss
            Debug.Log("You've Missed " + this.name);
            Destroy(gameObject, 2);
        }
    }
}
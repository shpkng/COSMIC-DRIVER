/*
 * File: Note.cs
 * Project: Script
 * File Created: Sunday, 27th May 2018 9:20:08 pm
 * Author: shpkng (shpkng@gmail.com)
 * -----
 * Last Modified: Friday, 1st June 2018 4:10:06 am
 * Modified By: shpkng (shpkng@gmail.com>)
 * -----
 * loving the lovely sunshine in autumn.♥
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private float opTimeNext;
    private float velocity;
    private int rotation;

    //成功触发的单个的我也不知道那个该叫什么
    int singleCount = 0;

    [SerializeField] SingleDog red;
    [SerializeField] SingleDog blue;

    GameControl g;

    void Start(){
        g = GameObject.Find("GameControl").GetComponent<GameControl>();
    }

    public void SetProperty(float t, float v, int rot)    //给三个属性赋值
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

    //加分
    public void SumPoints()
    {
        singleCount += 1;
        if(singleCount ==2)
        {
            g.AddPoints(200);
            Destroy(this.gameObject);
        } 
    }

    public void Exit()
    {
        //实际上想了一下，因为上面判定成功的时候就已经Destroy这个GameObject了，所以这个if语句实际上是多余的
        if (singleCount !=2)
        {
            //Miss
            Debug.Log("You've Missed This One");
			Destroy (this.gameObject);
        }
    }
}
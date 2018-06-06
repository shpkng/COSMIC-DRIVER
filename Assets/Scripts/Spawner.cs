/*
 * File: Spawner.cs
 * Project: Script
 * File Created: Sunday, 27th May 2018 9:20:08 pm
 * Author: shpkng (shpkng@gmail.com)
 * -----
 * Last Modified: Wednesday, 6th June 2018 4:01:04 am
 * Modified By: shpkng (shpkng@gmail.com>)
 * -----
 * loving the lovely sunshine in autumn.♥
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


/// <summary>
/// This Spawner will ONLY spawn class of Obstacle
/// </summary>
public class Spawner : MonoBehaviour
{
	#region This part shalln't be changed
	/// <summary>
	/// 定义一个序列数组
	/// </summary>
	Queue<Op> que = new Queue<Op>();
	int qCursor = 1;  //用来标记目前生成的序号
	float timer = 0f;
	float opTimeNext = 0f;
	[SerializeField] private GameObject[] gameObjectsToSpawn;

	int qLen = 0;

	public string path; //配置文件的路径
	string dPath;

	string[] lines; //配置文件的每一行

	GameObject note = null;

	[SerializeField] private bool isRunning = false;
	[SerializeField] private Transform spawnPlace;

	#endregion

	private void Awake()
	{
		dPath = Application.dataPath;
		GetOps();
	}

	/// <summary>
	/// The time step is 0.02s
	/// </summary>
	private void FixedUpdate()
	{
		if (isRunning)  //游戏运行中
		{
			timer += 0.02f; //时间步长
			if (timer >= opTimeNext && qCursor <= qLen) //达到步长&&还没走完
			{
				var qNow = que.Dequeue(); //目前的Op
				qCursor += 1;   //游标+1
				opTimeNext = qNow.opTimeNext;   //取出下一个Op的时间

				note = Instantiate(gameObjectsToSpawn[int.Parse(qNow.prePath)],spawnPlace.position + new Vector3(0,qNow.deltaY,0),Quaternion.identity);	//Y坐标的偏移量已经在这里体现了

				note.GetComponent<Obstacle>().SetProperty(opTimeNext, qNow.velocity,qNow.rot);
			}
		}
	}

	/// <summary>
	/// 读取配置文件
	/// </summary>
	public void GetOps()
	{
		lines = File.ReadAllLines(dPath + path);
		qLen = (int)int.Parse(lines[0]) / 1000;
		for (int i = 1; i <= (int)(int.Parse(lines[0]) / 1000); i++)
		{
			que.Enqueue(JsonUtility.FromJson<Op>(lines[i]));
		}
	}
}

/// <summary>
/// 一个Op就是一个Obstacle
/// </summary>
public class Op
{
	//index of this one in gameObjectToSpawn[]
	public string prePath;  
	//when the next one will be spawned
	public float opTimeNext;
	
	public float velocity;
	//delta Y
	public float deltaY;
	//rotation as a pattern
	public int rot;
}


//2018.5.25
//啊我要师妹
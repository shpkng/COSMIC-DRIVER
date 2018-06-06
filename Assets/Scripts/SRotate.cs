/*
 * File: SRotate.cs
 * Project: Script
 * File Created: Wednesday, 6th June 2018 2:01:17 am
 * Author: shpkng (shpkng@gmail.com)
 * -----
 * Last Modified: Wednesday, 6th June 2018 2:03:16 am
 * Modified By: shpkng (shpkng@gmail.com>)
 * -----
 * loving the lovely sunshine in autumn.♥
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRotate : MonoBehaviour
{

    public Vector3 自转角速度;
    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += 自转角速度 * Time.deltaTime;
    }
}

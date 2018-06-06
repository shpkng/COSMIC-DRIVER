
// Abandoned



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongDog : SingleDog
{

    private bool isIn = false;
    [SerializeField] int ppf = 0;   //Points per frame
    void OnTriggerEnter(Collider other)
    {
        isIn = true;
    }

    void OnTriggerExit(Collider other)
    {
        isIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isIn)
        {
            obstacle.SumPoints(ppf);
        }
    }
}

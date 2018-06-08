using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInner : MonoBehaviour
{
    [SerializeField] SingleDog.颜色_Color color;

    void OnTriggerEnter(Collider other)
    {
        if (color.GetHashCode() == other.GetComponent<SingleDog>()._颜色_Color.GetHashCode())
            other.GetComponent<SingleDog>().withMid = true;
    }

    void OnTriggerExit(Collider other)
    {
        other.GetComponent<SingleDog>().withMid = false;
    }
}

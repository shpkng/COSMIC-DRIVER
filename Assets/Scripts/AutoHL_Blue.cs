using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HighlightingSystem.Highlighter))]
public class AutoHL_Blue : MonoBehaviour
{
    void Start()
    {
        GetComponent<HighlightingSystem.Highlighter>().ConstantOn(Color.blue);
    }
}

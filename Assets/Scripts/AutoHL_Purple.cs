using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HighlightingSystem.Highlighter))]
public class AutoHL_Purple : MonoBehaviour {

	void Start () {
		 GetComponent<HighlightingSystem.Highlighter>().ConstantOn(new Vector4(0.5f,0.5f,0.5f,1)); 	//wo you bu zhi dao zi se shi ge shen me RGB zhi
	}

}

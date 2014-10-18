using UnityEngine;
using System.Collections;

public class MaskCutoff : MonoBehaviour {

	public float cutoff;
	
	// Update is called once per frame
	void Update () {
	
		renderer.material.SetFloat("_Cutoff", Mathf.InverseLerp(0, Screen.width, cutoff));

	}
}

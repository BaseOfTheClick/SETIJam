using UnityEngine;
using System.Collections;

public class LookAtCamera : MonoBehaviour {

	public Transform mainCam;

	void Start () {

		mainCam = Camera.main.transform;

	}

	// Update is called once per frame
	void Update () {
	
		transform.LookAt(mainCam.position);

	}

}

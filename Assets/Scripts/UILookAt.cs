using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class UILookAt : MonoBehaviour {

	
	// Update is called once per frame
	void FixedUpdate () {

		transform.LookAt(-Camera.main.transform.position);
//		gameObject.GetComponent<RectTransform>().LookAt(mainCamPos);

	}
}

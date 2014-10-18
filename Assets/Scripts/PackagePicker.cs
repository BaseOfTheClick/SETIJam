using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/**
TODO : Deal with other things to click on
*/
public class PackagePicker : MonoBehaviour {
    //the package to pick up
	private GameObject package;

    //camera that has a CameraController component attached
	public Camera specialCamera;
	
    //whether the camera should "orbit" or the mouse should pick up a package
	private bool orbiting;
	
	//deals with dropping the package in a SocietyBar
	//NEED UIElement that the mouse is over to complete this method
	void OnMouseUp() {
		
	}
	
	//deals with picking up the package
	void OnMouseDown() {
		//ray from camera
		Ray camRay = specialCamera.ScreenPointToRay(Input.mousePosition);
		
		//info about what the ray hit
		RaycastHit rayHit;
		
		//Get the raycast hit
		if (Physics.Raycast(camRay, out rayHit)) {
		
			//check if it's a package 
			//IMPORTANT : replace PLACEHOLDER with package tag
			if (rayHit.transform.gameObject.CompareTag("PLACEHOLDER")) {
			
				//store the package reference
				package = rayHit.transform.gameObject;
				
				//don't orbit the camera
				orbiting = false;
			}
			
			//orbit the camera for all other cases
			else {
				orbiting = true;
			}
		}
		else {
			orbiting = true;
		}
	}
	
	//fancy function
	public void doCameraOrbit() {
		specialCamera.gameObject.GetComponent<CameraController>().DoCamOrbit();
	}
	
	bool hasPackage() {
		return (package == null);
	}
	
	GameObject removePackage() {
        GameObject toRemove = package;
        this.package = null;
        return toRemove;
	}
	
	public void LateUpdate() {
		if (orbiting) {
			doCameraOrbit();
		}
	}
}
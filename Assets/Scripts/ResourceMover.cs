using UnityEngine;
using System.Collections;

public class ResourceMover : MonoBehaviour {
    [System.NonSerialized]
    public GameObject resourcePackage;
    [System.NonSerialized]
    public Camera mainCam;

    private bool camOrbitEnabled = false;
    private bool pickupEnabled = false;

    RaycastHit camHit;
    
    // Use this for initialization
	void Start () {
        mainCam = Camera.main;
	}

    

	// Update is called once per frame
	void Update () 
    {
        if (Input.GetButtonDown("Fire1"))
        {
            pollInput();
        }
        if (pickupEnabled)
        {
            pickupResource(camHit);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            resetChecks();
        }

	}
    void LateUpdate()
    {
        if (camOrbitEnabled)
        {
            mainCam.GetComponent<CameraController>().DoCamOrbit(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    void pollInput()
    {
        Ray camRay = mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(camRay, out camHit))
        {
            if (camHit.transform.gameObject.CompareTag("ResourcePackage"))
            {
                pickupEnabled = true;
            }
            else
            {
                Debug.Log("Didn't Hit the Resource");
            }
        }
        else
        {
            Debug.Log("Hit Nothing");
            camOrbitEnabled = true;
            camHit = new RaycastHit();
        }
    }

    void resetChecks()
    {
        pickupEnabled = false;
        camOrbitEnabled = false;
    }

    void pickupResource(RaycastHit camHit)
    {
        Debug.Log("Hit Resource");
        GameObject rPack = camHit.transform.gameObject;
        rPack.GetComponent<ResourcePackage>().MoveMeWithMouse();
    }
}

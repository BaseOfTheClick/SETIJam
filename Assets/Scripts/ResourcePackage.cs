﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourcePackage : MonoBehaviour {
    public int resourceQuantity = 5;
    public float lerpTime = 2;
    public float distanceFromCam = 1.6f;

    private bool inCollider = false;

    GameObject collidingWith;

    public void MoveMeWithMouse()
    {
        Vector3 currentPos = this.transform.position;
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z - distanceFromCam;
        Vector3 newPos = Camera.main.ScreenToWorldPoint(mousePos);

        this.transform.position = newPos;


        //Debug.Log("Position : (" + transform.position.x + ", " + transform.position.y + ", " + transform.position.z + ")") ;
    }

    void OnCollisionEnter(Collision col)
    {
        inCollider = true;
        collidingWith = col.gameObject;

        Debug.Log("Entered trigger");
    }

    void OnCollisionExit(Collision col)
    {
        inCollider = false;
        collidingWith = null;

        Debug.Log("Exited Trigger");
    }
}

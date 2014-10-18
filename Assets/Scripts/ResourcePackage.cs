using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourcePackage : MonoBehaviour {
    public int resourceQuantity = 5;
    public float lerpTime = 2;
    public float distanceFromCam = 18.6f;

    private bool inCollider = false;

    GameObject collidingWith;

    public void MoveMeWithMouse()
    {
        Vector3 currentPos = this.transform.position;
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = distanceFromCam;
        Vector3 newPos = Camera.main.ScreenToWorldPoint(mousePos);

        this.transform.position = newPos;


        Debug.Log("Position : (" + transform.position.x + ", " + transform.position.y + ", " + transform.position.z + ")") ;
    }

    void OnTriggerEnter(Collider col)
    {
        inCollider = true;
        collidingWith = col.gameObject;
    }

    void OnTriggerExit(Collider col)
    {
        inCollider = false;
        collidingWith = null;
    }

    void OnMouseUp()
    {
        if (inCollider)
        {
            if (collidingWith != null)
            {
                collidingWith.GetComponent<SocietyBar>().addResources(resourceQuantity);
                collidingWith.GetComponent<SocietyBar>().conveyResources();
                Destroy(this);
            }
            else
            {
                Debug.Log("Resource Package is in collider but reference to collidingWith was not stored");
            }
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourcePackage : MonoBehaviour {
    public int resourceQuantity = 5;
    private bool inCollider = false;

    GameObject collidingWith;

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

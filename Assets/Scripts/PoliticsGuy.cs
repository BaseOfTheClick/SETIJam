using UnityEngine;
using System.Collections;

public class PoliticsGuy : MonoBehaviour {
    public GameObject politicsGroupObject;

    public bool isPolitician(GameObject obj)
    {
        foreach (Transform t in politicsGroupObject.transform)
        {
            if (t.gameObject == obj)
            {
                return true;
            }
        }
        return false;
    }
}

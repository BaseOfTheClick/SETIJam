using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/**
 TODO : Add class description
*/
public class SocietyBar : MonoBehaviour
{
    //rate of change
    //percent value
    public float rateOfChange;

    //normalized percent between -1 and 1
    public float rateRange;

    //discrete value 
    public float resources = 50;

    //max resource value
    public int resourcesMax = 100;

    //constants for visual rep. of values
    public float minGfx = 68f;
    public float maxGfx = 200f;

    //private float timeAccumulate = 0;

    //default constructor
    //doesn't set anything
    public SocietyBar() { }

    ////sets initial values or rateOfChange and resources
    //public SocietyBar(float rateOfChange, int resources)
    //{
    //    this.rateOfChange = rateOfChange;
    //    this.resources = resources;
    //}

    public void Start()
    {
        conveyResources();
    }

    public float getRateOfChange()
    {
        return rateOfChange;
    }

    public float getResources()
    {
        return resources;
    }

    public void setRateOfChange(float rOC)
    {
        this.rateOfChange = rOC;
    }

    public void setResources(int res)
    {
        this.resources = res;
    }

    //shortcut to writing setResources(getResources() + some_num)
    public void addResources(int val)
    {
        this.resources += val;
    }

    //translate discrete resource quantity to graphical representation
    public void conveyResources()
    {

        RectTransform barRect = new RectTransform();

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("bar"))
        {
            if (obj.transform.parent.transform.parent == this.transform)
            {
                barRect = obj.GetComponent<RectTransform>();
            }
        }
        float diff = minGfx + ((resources * (maxGfx - minGfx)) / 100);

        //Debug.Log(diff);

        barRect.sizeDelta = new Vector2(diff, diff);
    }

    //updates the resources based on the rate of change
    public void updateResources()
    {
        float randomDiff = (UnityEngine.Random.value < 0.5f) ? (UnityEngine.Random.value * rateRange) : -(UnityEngine.Random.value * rateRange);
        resources = (resources - rateOfChange < 0) ? 0 : resources - (float)(rateOfChange + randomDiff) * Time.deltaTime;
    }

    public void Update()
    {
        updateResources();
        conveyResources();
    }
}
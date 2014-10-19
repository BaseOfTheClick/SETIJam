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
    public float resources = 75;

    //max resource value
    public int resourcesMax = 100;

    //constants for visual rep. of values
    public float minGfx = 7.5f;
    public float maxGfx = 20f;

    //the random, constant value of a bar's difference in rate of change
    private float randDiff;

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

    static bool setMin = false;
    static bool setMax = false;

    public void Start()
    {
        conveyResources();
        //float diff = UnityEngine.Random.value * rateRange;

        //diff = (UnityEngine.Random.value > 50) ? diff : -diff;

        //rateOfChange -= diff;

        rateOfChange = (UnityEngine.Random.RandomRange(1, rateRange) * rateOfChange);

        //rateOfChange = Mathf.Clamp(rateOfChange, 0.001f, 100f);
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

    public void setRateRange(float rr)
    {
        this.rateRange = rr;
    }

    //adds a value to the rate of change
    public void increaseRateOfChange(float toAdd)
    {
        this.rateOfChange += toAdd;
    }

    //increases the rate of change by a factor of the parameter
    public void increaseRateOfChangeBy(float toMultiply)
    {
        this.rateOfChange *= toMultiply;
    }

    public void addToRateRange(float toAdd)
    {
        this.rateRange += toAdd;
    }
    public void multiplyRateRange(float toMultiply)
    {
        this.rateRange *= toMultiply;
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
        resources -= (resources * (rateOfChange / 100) * Time.deltaTime);
        resources = Mathf.Clamp(resources, 0, 100);
    }

    public void Update()
    {
        updateResources();
        conveyResources();
    }
}
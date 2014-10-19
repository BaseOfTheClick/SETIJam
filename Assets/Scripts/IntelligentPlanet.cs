using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/**
Add class description please
*/
public class IntelligentPlanet : MonoBehaviour {
	//rate of the change of the resources on this planet
	public float rateOfChange;
	
	//number of resources on the planet
    [SerializeField]
	private int resources;
	
	//default constructor
	//does nothing
	public IntelligentPlanet() {}
	
	//gives default values to fields
	public IntelligentPlanet(float rateOfChange, int resources) {
		this.rateOfChange = rateOfChange;
		this.resources = resources;
	}
	
	public float getRateOfChange() {
		return rateOfChange;
	}
	
	public int getResources() {
		return resources;
	}
	
	public void setResources(int res) {
		this.resources = res;
	}
	
	public void setRateOfChange(float rateOfChange) {
		this.rateOfChange = rateOfChange;
	}
	
	public int takeResources(int packageSize) {
		resources -= packageSize;
		
		return packageSize;
	}
}
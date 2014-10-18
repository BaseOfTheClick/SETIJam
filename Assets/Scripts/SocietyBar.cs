using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/**
 TODO : Add class description
*/
public class SocietyBar : MonoBehaviour {
	//rate of change
	public float rateOfChange;
	
	//discrete value 
	public int resources;
	
	//default constructor
	//doesn't set anything
	public SocietyBar() {}
	
	//sets initial values or rateOfChange and resources
	public SocietyBar(float rateOfChange, int resources) {
		this.rateOfChange = rateOfChange;
		this.resources = resources;
	}
	
	public float getRateOfChange() {
		return rateOfChange;
	}
	
	public int getResources() {
		return resources;
	}
	
	public void setRateOfChange(float rOC) {
		this.rateOfChange = rOC;
	}
	
	public void setResources(int res) {
		this.resources = res;
	}
	
	//shortcut to writing setResources(getResources() + some_num)
	public void addResources(int val) {
		this.resources += val;
	}
	
	//updates the resource value based on the rate of change
	//returns whether the value was less than 0 upon updating resources
	public bool updateResources() {
		bool lessThanZero;
		
		resources = resources + (int)(resources * rateOfChange);
		
		lessThanZero = (resources < 0) ? true : false;
		
		resources = (lessThanZero) ? 0 : resources;
		
		return lessThanZero;
	}
}
using UnityEngine;
using System.Collections;

public class GlobalRateController : MonoBehaviour {
    public float initialResourceSpawnRate = 1;
    public float initialBarDepletionRate = 1.5f;
    public float initialRateRange = 0.5f;

    private const string planetTag = "planet";
    private const string societyBarTag = "barbox";

    private GameObject planet;
    private GameObject[] societyBars;

    private bool scienceIsLow = false;
    private bool econIsLow = false;


    void Awake()
    {
        planet = GameObject.FindGameObjectWithTag(planetTag);
        societyBars = GameObject.FindGameObjectsWithTag(societyBarTag);

        planet.GetComponent<IntelligentPlanet>().setSpawnRate(initialResourceSpawnRate);

        foreach (GameObject obj in societyBars)
        {
            obj.GetComponent<SocietyBar>().setRateOfChange(initialBarDepletionRate);
            obj.GetComponent<SocietyBar>().setRateRange(initialRateRange);
        }
    }

    public bool isScienceLow()
    {
        return scienceIsLow;
    }

	// Update is called once per frame
	void Update () {
        foreach (GameObject obj in societyBars)
        {
            if (obj.GetComponent<SocietyBar>().getResources() <= 0)
            {
                if (this.GetComponent<ScienceGuy>().isScienceGuy(obj))
                {
                    this.scienceIsLow = true;
                }
                if (this.GetComponent<EconGuy>().isEconomist(obj))
                {
                    this.econIsLow = true;
                    //this.GetComponent<ChangeGlobalRates>().changeResourceSpawnRate();
                }
                if (this.GetComponent<PoliticsGuy>().isPolitician(obj))
                {
                    Application.LoadLevel(0);
                }
            }
        }
	}
}

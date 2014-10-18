using UnityEngine;
using System.Collections;

public class ResourceSpawner : MonoBehaviour {
    public GameObject resourcePackage;

    public IntelligentPlanet planet;
    private Vector3[] planetVertices;

    private float timeInterval = 3f;
    private float timeAccumulate = 0;

	// Use this for initialization
	void Start () {
        planet = this.GetComponent<IntelligentPlanet>();
        planetVertices = planet.GetComponent<MeshFilter>().mesh.vertices;
        timeInterval = this.GetComponent<IntelligentPlanet>().rateOfChange;
	}
	
	// Update is called once per frame
	void Update () {
        timeAccumulate += Time.deltaTime;

        if (timeAccumulate >= timeInterval)
        {
            Vector3 randomVertex = planetVertices[Random.Range(0, planetVertices.Length)];
            GameObject clone = Instantiate(resourcePackage, randomVertex, Quaternion.identity) as GameObject;
            clone.transform.parent = planet.gameObject.transform;
            timeAccumulate = 0;
        }
	}
}

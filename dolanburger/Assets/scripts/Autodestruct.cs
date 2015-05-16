using UnityEngine;
using System.Collections;

public class Autodestruct : MonoBehaviour {

	public float timeToAutodestruct = 4;
	float time;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= timeToAutodestruct) {
			Destroy(this.transform.gameObject);
		}
	}
}

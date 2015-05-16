using UnityEngine;
using System.Collections;

public class DiamondCase : MonoBehaviour {

	static public bool isOpen = false;
	public float timeToOpen = 1;
	public float time = 0;

	bool opening = false;

	public GameObject finalPosiotionObj;

	Vector3 finalPosition;
	Vector3 startingPos;

	public void FlipFlopCaseDoor()
	{
		opening = true;
	}

	// Use this for initialization
	void Start () {
		startingPos = this.transform.position;
		finalPosition = finalPosiotionObj.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (opening == false) {
			return;
		}

		if (time >= timeToOpen) {
			opening = false;
			isOpen = !isOpen;
			time = 0;
			return;
		}

		time += Time.deltaTime;
		if (isOpen == true) {
			transform.position = finalPosition - (finalPosition - startingPos) * time / timeToOpen;
		} else {
			transform.position = (finalPosition - startingPos) * time / timeToOpen + startingPos;
		}

	}
}

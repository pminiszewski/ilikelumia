using UnityEngine;
using System.Collections;

public class CatchingDrop : MonoBehaviour {

	public void CatchDrop(GameObject catched)
	{
		var temp = catched.GetComponent<Item> ();
		Debug.Log ("Catched : " + temp.gameObject.name);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

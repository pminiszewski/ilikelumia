using UnityEngine;
using System.Collections;

public class PlateDropZone : MonoBehaviour, IObjectDropHandler
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	#region IObjectDropHandler implementation

	public void HandleDrop (GameObject obj)
	{
		GetComponentInParent<Order>().HandleDrop(obj);
	}

	#endregion
}

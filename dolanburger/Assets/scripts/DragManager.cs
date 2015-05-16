using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class DragManager : MonoBehaviour {

	public EventSystem eventSystem;
	public GameObject FailStateObject;
	public GameObject ContainerForDragging;

	public GameObject currentlyOver;

	Vector3 dragStartedFrom = new Vector2();
	bool dragStarted = false;
	public GameObject draggedObj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		PointerEventData ped = new PointerEventData (eventSystem);
		ped.position = Input.mousePosition;
		List<RaycastResult> raycastResults = new List<RaycastResult>();
		EventSystem.current.RaycastAll (ped, raycastResults);

		if (raycastResults.Count > 0) {
			currentlyOver = raycastResults[0].gameObject;
		}

		if (dragStarted == true)
		{
			draggedObj.transform.position = Input.mousePosition;
		}
	}

	public void DragBegin() 
	{
		Debug.Log ("Start");
		
		//draggedObj = currentlyOver;
		draggedObj = currentlyOver.gameObject.GetComponent<Bucket> ().OnSpawnItem ();

		dragStartedFrom = currentlyOver.gameObject.transform.position;
		draggedObj.gameObject.transform.SetParent (ContainerForDragging.transform);
		dragStarted = true;
	}
	
	public void DragEnd() 
	{
		dragStarted = false;

		if (currentlyOver.gameObject == FailStateObject) {
			draggedObj.transform.position = dragStartedFrom;
			DestroyObject(draggedObj);
			draggedObj = null;
			return;
		}

		currentlyOver.gameObject.GetComponent<CatchingDrop> ().CatchDrop (draggedObj);

		draggedObj.gameObject.transform.SetParent (FailStateObject.transform);
		draggedObj = null;

	}
	
	public void POver (int i = 0)
	{
		Debug.Log ("End" + i.ToString() + eventSystem.alreadySelecting.ToString ());
	}
}

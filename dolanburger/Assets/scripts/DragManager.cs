using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public interface IObjectDropHandler
{
	void HandleDrop(GameObject obj);
}

public class DragManager : MonoBehaviour {

	public EventSystem eventSystem;
	public GameObject FailStateObject;
	public GameObject ContainerForDragging;

	public GameObject currentlyOver;

	Vector3 dragStartedFrom = new Vector2();
	bool dragStarted = false;
	public GameObject draggedObj;
	Transform startedParent;

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

	public void DragBeginBucket() 
	{
		draggedObj = currentlyOver.gameObject.GetComponent<IBucket> ().OnSpawnItem ();


		dragStartedFrom = currentlyOver.gameObject.transform.position;
		draggedObj.gameObject.transform.SetParent (ContainerForDragging.transform);

		//draggedObj.AddComponent<Autodestruct> ();

		var item = draggedObj.gameObject.GetComponent<Item> ();
		if (item != null) {
			item.dManager = this;
		}

		dragStarted = true;
	}

	public void DragBegin() 
	{
		draggedObj = currentlyOver;
		startedParent = currentlyOver.transform.parent;
		dragStartedFrom = currentlyOver.gameObject.transform.position;
		draggedObj.gameObject.transform.SetParent (ContainerForDragging.transform);



		var item = draggedObj.gameObject.GetComponent<Item> ();
		item.dManager = this;

		dragStarted = true;
	}
	
	public void DragEnd() 
	{
		dragStarted = false;

		var detected = currentlyOver.gameObject.GetComponent<IObjectDropHandler> ();
		if (detected == null) {
			//Debug.LogError("NIE MA!");
			draggedObj.transform.position = dragStartedFrom;
			DestroyObject(draggedObj);
			draggedObj = null;
			return;
		}
		
		detected.HandleDrop(draggedObj);

		draggedObj.gameObject.transform.SetParent (currentlyOver.transform);
		draggedObj = null;

	}

	public void DragEndFromGrill() 
	{
		dragStarted = false;

		var detected = currentlyOver.gameObject.GetComponent<IObjectDropHandler> ();
		if (detected == null) {
			draggedObj.transform.position = dragStartedFrom;
			Destroy(draggedObj);
			draggedObj = null;
			return;
		}

		detected.HandleDrop(draggedObj);

		draggedObj.gameObject.transform.SetParent (startedParent);
		draggedObj = null;
		
	}
	
	public void POver (int i = 0)
	{
		Debug.Log ("End" + i.ToString() + eventSystem.alreadySelecting.ToString ());
	}
}

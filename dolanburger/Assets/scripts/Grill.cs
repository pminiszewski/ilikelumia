using UnityEngine;
using System.Collections.Generic;

public class Grill : MonoBehaviour, IObjectDropHandler
{
	public List<Item> Items
	{
		get
		{
			return new List<Item>(GetComponentsInChildren<Item>());
		}
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void AddToGrill(Item item)
	{
		Debug.Log("Cook!");
			item.Grill(this);

	}

	public void RemoveFromGrill(Item item)
	{
		item.Stop();
	}

	public void OnItemBurned(Item item)
	{

	}

	public void HandleDrop(GameObject obj)
	{
		//Debug.Log("Handle drop" + obj.GetComponent<Item>().FType);
		Item i = obj.GetComponent<Item>();
		if(i != null)
		{
			AddToGrill(i); 
		}
		else
		{
			Destroy(i.gameObject);
		}
	}
}

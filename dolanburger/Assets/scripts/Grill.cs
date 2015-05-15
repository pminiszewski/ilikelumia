using UnityEngine;
using System.Collections.Generic;

public class Grill : MonoBehaviour 
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
		if(!Items.Contains(item))
		{
			Items.Add(item);
			item.Grill(this);
		}
	}

	public void RemoveFromGrill(Item item)
	{
		Items.Remove(item);
		item.Stop();
	}

	public void OnItemBurned(Item item)
	{

	}
}

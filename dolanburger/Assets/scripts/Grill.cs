using UnityEngine;
using System.Collections.Generic;

public class Grill : MonoBehaviour 
{
	public List<Item> Items = new List<Item>();

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
		if(!Items.Contains())
		{
			Items.Add(item);
			item.Grill();
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

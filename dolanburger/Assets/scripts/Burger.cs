using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public enum FoodType
{
	Meat,
	Tomato,
	Cheese,
	Vege
};





public class Burger : MonoBehaviour 
{
    public int wantedLevel;

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

	public void AddItem(Item i)
	{
		i.transform.parent = transform;
	}
}

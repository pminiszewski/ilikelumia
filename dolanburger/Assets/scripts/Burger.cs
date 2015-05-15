﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public enum FoodType
{
	Meat,
	Tomato,
	Cheese,
	Vege
};

public class Item : MonoBehaviour
{
	
	public bool HasDiamond;
	public int Level;
	public FoodType FType;
	public bool IsBurned;
	private Grill _Grill;

	public void Grill(Grill g)
	{
		_Grill = g;
		transform.parent = g.transform;
		StartCoroutine(Grilling());
	}

	public void Stop()
	{
		_Grill = null;
		transform.parent = null;
		StopAllCoroutines();
	}

	private IEnumerator Grilling()
	{
		while(Level < 4)
		{
			yield return new WaitForSeconds(GetGrillTime());
			Level++;
			Debug.Log(string.Format("Grilled {0} to level {1}", FType.ToString(), Level));
		}
		IsBurned = true;
		_Grill.OnItemBurned(this);
	}

	private float GetGrillTime()
	{
		float t = 0;
		switch (FType)
		{
		case FoodType.Cheese:
			t = 1;
			break;
		case FoodType.Meat:
			t = 3;
			break;
		case FoodType.Tomato:
			t = 1.5f;
			break;
		case FoodType.Vege:
			t = 2;
			break;
		default:
			break;
		}

		return t;
	}
}



public class Burger : MonoBehaviour 
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

	public void AddItem(Item i)
	{
		i.transform.parent = transform;
	}
}

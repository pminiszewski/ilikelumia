using UnityEngine;
using System.Collections.Generic;

public enum FoodType
{
	Meat,
	Tomato,
	Cheese,
	Vege
};

public class Item 
{
	
	public bool HasDiamond;
	public int Level;
	public FoodType Type;
}

public class Burger : MonoBehaviour 
{
	public List<Item> Items = new List<Item>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

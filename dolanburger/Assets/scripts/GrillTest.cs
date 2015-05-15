using UnityEngine;
using System.Collections;
using System;

public class GrillTest : MonoBehaviour 
{

	public void AddToGrill()
	{
		Grill g = GameObject.FindObjectOfType<Grill>();

		GameObject go = new GameObject();
		Item i =  go.AddComponent<Item>();
		Array values = Enum.GetValues(typeof(FoodType));

		FoodType randomBar = (FoodType)values.GetValue(UnityEngine.Random.Range(0, values.Length -1));
		i.FType = randomBar;
		go.name = "Item_"+randomBar.ToString();
		g.AddToGrill(i);

	}
}

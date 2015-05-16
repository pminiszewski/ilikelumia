using UnityEngine;
using System.Collections;
using System;

public class GrillTest : MonoBehaviour 
{

	public void AddToGrill()
	{
		Grill g = GameObject.FindObjectOfType<Grill>();


		//g.AddToGrill(CreateRandomItem());

		CreateRandomBurger();


	}
	public static Burger CreateRandomBurger()
	{
		GameObject go = new GameObject();
		Burger b =  go.AddComponent<Burger>();
        // add items
		for(int i=0; i<UnityEngine.Random.Range(3,6); i++)
		{
			Item it = CreateRandomItem();
			b.AddItem(it);
		}
        // set variables
        b.wantedLevel = UnityEngine.Random.Range(0, 3);
		return b;
	}
	public static Item CreateRandomItem()
	{
		GameObject go = new GameObject();
		Item i =  go.AddComponent<Item>();
		Array values = Enum.GetValues(typeof(FoodType));
		
		FoodType randomBar = (FoodType)values.GetValue(UnityEngine.Random.Range(0, values.Length -1));
		i.FType = randomBar;
		go.name = "Item_"+randomBar.ToString();
		return i;
	}
}

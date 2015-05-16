using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

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
		for(int i=0; i<UnityEngine.Random.Range(1,4); i++)
		{
			Item it = CreateRandomItem();
			b.AddItem(it);
		}
        // set variables
        //b.wantedLevel = UnityEngine.Random.Range(0, 3);
		return b;
	}
	public static Item CreateRandomItem()
	{
		GameObject go = new GameObject();
		Item i =  go.AddComponent<Item>();
		Array values = Enum.GetValues(typeof(FoodType));
		
		FoodType randomBar = (FoodType)values.GetValue(UnityEngine.Random.Range(0, values.Length ));
		i.FType = randomBar;

		i.Level = UnityEngine.Random.Range(0, 3);

		go.AddComponent<Image>().sprite = i.GetFoodImage();
		go.name = "Item_"+randomBar.ToString();
		return i;
	}
}

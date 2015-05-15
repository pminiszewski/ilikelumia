using UnityEngine;
using System.Collections;

public class Bucket : MonoBehaviour 
{

	public FoodType BucketType;


	public void OnSpawnItem()
	{
		GameObject go = new GameObject();

		Item i = go.AddComponent<Item>();
		i.FType = BucketType;
		go.name = "Item_"+i.FType.ToString();
	}

}

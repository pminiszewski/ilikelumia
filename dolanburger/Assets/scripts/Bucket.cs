using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bucket : MonoBehaviour 
{
	public Item ItemPrefab;
	public FoodType BucketType;



	public void OnSpawnItem()
	{
		GameObject go = Instantiate<GameObject>(ItemPrefab.gameObject);
		Item i = go.GetComponent<Item>();
		go.name = "Item_"+i.FType.ToString();
		i.transform.parent = transform;

	}

}

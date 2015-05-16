using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DiamondBucket : MonoBehaviour 
{
	public Diamond ItemPrefab;
	public FoodType BucketType;


	public GameObject OnSpawnItem()
	{
		GameObject go = Instantiate<GameObject>(ItemPrefab.gameObject);
		Item i = go.GetComponent<Item>();
		go.name = "Item_"+i.FType.ToString();
		i.transform.parent = transform;
		return go;
	}

}

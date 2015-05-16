using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public interface IBucket
{
	GameObject OnSpawnItem();
}

public class Bucket : MonoBehaviour, IBucket 
{
	public Item ItemPrefab;
	public FoodType BucketType;


	public GameObject OnSpawnItem()
	{
		GameObject go = Instantiate<GameObject>(ItemPrefab.gameObject);
		Item i = go.GetComponent<Item>();
		i.FType = BucketType;
		go.name = "Item_"+i.FType.ToString();
		i.transform.SetParent( transform);
		return go;
	}

}

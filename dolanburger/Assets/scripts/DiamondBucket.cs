using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DiamondBucket : MonoBehaviour, IBucket
{
	public Diamond ItemPrefab;


	public GameObject OnSpawnItem()
	{
		GameObject go = Instantiate<GameObject>(ItemPrefab.gameObject);
		Diamond i = go.GetComponent<Diamond>();
		i.transform.parent = transform;
		return go;
	}

}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Item : MonoBehaviour, IObjectDropHandler
{
	public Sprite Meat1Image;
	public Sprite Meat2Image;
	public Sprite Meat3Image;
	public Sprite Meat4Image;
	public Sprite Cheese1Image;
	public Sprite Cheese2Image;
	public Sprite Cheese3Image;
	public Sprite Cheese4Image;
	public Sprite Tomato1Image;
	public Sprite Tomato2Image;
	public Sprite Tomato3Image;
	public Sprite Tomato4Image;
	public Sprite Vege1Image;
	public Sprite Vege2Image;
	public Sprite Vege3Image;
	public Sprite Vege4Image;

	public bool HasDiamond;
	public int Level;
	public FoodType FType;
	public bool IsBurned;
	private Grill _Grill;

	public DragManager dManager;
	
	public void Grill(Grill g)
	{
		_Grill = g;
		StartCoroutine(Grilling());
	}
	
	public void Stop()
	{
		_Grill = null;
		StopAllCoroutines();
	}
	void Start()
	{
		GetComponent<Image>().sprite = GetFoodImage();
	}
	private IEnumerator Grilling()
	{
		while(Level < 3)
		{
			yield return new WaitForSeconds(GetGrillTime());
			Level++;
			GetComponent<Image>().sprite = GetFoodImage();
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

	public void DragBegin()
	{
		dManager.DragBegin ();
		Stop();
	}

	public void DragEnd()
	{
		dManager.DragEndFromGrill ();
	}

	public void HandleDrop(GameObject obj)
	{
		Diamond d = obj.GetComponent<Diamond>();
		if(d != null)
		{
			HasDiamond = true;
			Destroy(obj);
			Debug.Log("Added diamond");
		}
	}

	public Sprite GetFoodImage()
	{
		Sprite ret = null;
		switch (FType) {
		case FoodType.Cheese:
			switch(Level)
			{
			case 0:
				ret = Cheese1Image;
				break;
			case 1:
				ret = Cheese2Image;
				break;
			case 2:
				ret = Cheese3Image;
				break;
			case 3:
				ret = Cheese4Image;
				break;
			}
			break;
		case FoodType.Meat:
			switch(Level)
			{
			case 0:
				ret = Meat1Image;
				break;
			case 1:
				ret = Meat2Image;
				break;
			case 2:
				ret = Meat3Image;
				break;
			case 3:
				ret = Meat4Image;
				break;
			}
			break;
		case FoodType.Tomato:
			switch(Level)
			{
			case 0:
				ret = Tomato1Image;
				break;
			case 1:
				ret = Tomato2Image;
				break;
			case 2:
				ret = Tomato3Image;
				break;
			case 3:
				ret = Tomato4Image;
				break;
			}
			break;
		case FoodType.Vege:
			switch(Level)
			{
			case 0:
				ret = Vege1Image;
				break;
			case 1:
				ret = Vege2Image;
				break;
			case 2:
				ret = Vege3Image;
				break;
			case 3:
				ret = Vege4Image;
				break;
			}
			break;
		}
		return ret;

	}
}
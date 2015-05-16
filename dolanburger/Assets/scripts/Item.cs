using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
	
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
	
	private IEnumerator Grilling()
	{
		while(Level < 4)
		{
			yield return new WaitForSeconds(GetGrillTime());
			Level++;
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
	}

	public void DragEnd()
	{
		dManager.DragEndFromGrill ();
	}
}
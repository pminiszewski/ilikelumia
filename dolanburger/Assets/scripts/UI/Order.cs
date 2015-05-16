using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Order : MonoBehaviour, IObjectDropHandler
{

    /*
    cheese:	f6f229 	f0cf2e 	f2a92c
    green:	069743 	108341 	166424
    meat:	cc64a7 	89193a  3b1a0c
    tomato:	e00f16 	cf2921  a4321c
    */
    string[] ColorCode =
    {
        "f6f229",  "f0cf2e",  "f2a92c",
        "069743",  "108341",  "166424",
        "cc64a7",  "89193a",  "3b1a0c",
        "e00f16",  "cf2921",  "a4321c"
    };
    //0 - 2 cheese, 3-5 green etc
    int FoodTypeColorCode = 0;
    List<Color> Colors = new List<Color>();

    public bool Free = true;
    public GameObject Plate;
    public GameObject OrderSign;

    public Burger BurgerOrdered;
    public Burger BurgerReceived;
    public Burger BurgerRecivedObj;

    public Image LoafUp;
    public Image LoafDown;
    public Image Foodtype;

    public Image BurgerBottom;
    public Image BurgerTop;

    public List<GameObject> Children;
    public List<Image> PlateList;
    //Meat, Cheese, Vege, Tomato
    public List<Image> Food;

    private int ItemsOnPlateOffset;
    private int OrderedItemsCount;
    DuckQueue Queue;
    Duck _Duck;

    // Use this for initialization
    void Start()
    {
        Queue = FindObjectOfType<DuckQueue>();
    }

    public static Color hexToColor(string hex)
    {
        byte a = 255;
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

        return new Color32(r, g, b, a);
    }

    public void CreateOrder(Duck duck, int index)
    {

        _Duck = duck;
        for (int i = 0; i < ColorCode.Length; i++)
        {
            Colors.Add(hexToColor(ColorCode[i]));
        }
        
        BurgerOrdered = duck.burger;
        AddLoafToPlate(BurgerBottom, Vector2.zero);
        BurgerRecivedObj = GameObject.Instantiate(BurgerReceived) as Burger;
        BurgerRecivedObj.name = "RecivedBurger";
        BurgerRecivedObj.transform.parent = Plate.transform;
        BurgerRecivedObj.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        BurgerRecivedObj.gameObject.SetActive(true);
        OrderedItemsCount = duck.burger.Items.Count;
        for (int i = -1; i < duck.burger.Items.Count + 1; i++)
        {
            Image food;
            if (i == -1)
            {
                food = GameObject.Instantiate(LoafDown.gameObject).GetComponent<Image>();
                food.rectTransform.SetParent(OrderSign.transform);
                Children.Add(food.gameObject);
                continue;
            }
            else if (i == duck.burger.Items.Count)
            {
                food = GameObject.Instantiate(LoafUp.gameObject).GetComponent<Image>();
                food.rectTransform.SetParent(OrderSign.transform);
                Children.Add(food.gameObject);
                continue;
            }

            food = GameObject.Instantiate(Foodtype.gameObject).GetComponent<Image>();

            switch (duck.burger.Items[i].FType)
            {
                case FoodType.Cheese:
                    FoodTypeColorCode = 0;
                    break;
                case FoodType.Meat:
                    FoodTypeColorCode = 6;
                    break;
                case FoodType.Tomato:
                    FoodTypeColorCode = 9;
                    break;
                case FoodType.Vege:
                    FoodTypeColorCode = 3;
                    break;
            }

            switch (duck.burger.Items[i].Level)
            {
                case 0:
                    food.color = Colors[FoodTypeColorCode];
                    break;
                case 1:
                    food.color = Colors[FoodTypeColorCode  + 1];
                    break;
                case 2:
                    food.color = Colors[FoodTypeColorCode + 2];
                    break;
                case 3:
                    food.color = Color.black;
                    break;
            }
            food.rectTransform.SetParent(OrderSign.transform);
            Children.Add(food.gameObject);
        }

        OrderSign.gameObject.SetActive(true);

        Free = false;
    }

	public bool ValidateOrder()
	{
		List<Item> o = BurgerOrdered.Items;
		List<Item> r = BurgerRecivedObj.Items;
        bool hasDiamonds = false;
		if(o.Count != r.Count)
		{
			return false;
		}
        for (int i = 0; i < r.Count; i++)
        {
            bool t = o[i].FType == r[i].FType;
            t &= o[i].Level == r[i].Level;
            t &= o[i].HasDiamond == r[i].HasDiamond;
            if (!t)
                return false;
            if (r[i].HasDiamond)
                hasDiamonds = true;
        }
        switch (_Duck.duckType)
        {
            case Duck.DuckType.Normal:
                if (hasDiamonds)
                    GameState.score -= 200;
                break;
            case Duck.DuckType.Mafia:
                if (hasDiamonds)
                    GameState.score += 200;
                break;
            case Duck.DuckType.Police:
                if (hasDiamonds)
                    GameState.score -= 500;
                break;
            default:
                break;
        }
        return true;
    }
    public void OrderComplete()
    {
        bool isGood = ValidateOrder();
        if (!isGood)
        {
            GameState.nrOfFailures++;
            Queue.ShowCard(_Duck);
        }


        for (int i = 0; i < Children.Count; i++)
        {
            GameObject.Destroy(Children[i]);
        }
        for (int i = 0; i < PlateList.Count; i++)
        {
            GameObject.Destroy(PlateList[i].gameObject);
        }

        Children.Clear();
        PlateList.Clear();

        OrderSign.gameObject.SetActive(false);
        BurgerRecivedObj.gameObject.SetActive(false);
        Free = true;
        BurgerComplete = false;
        Queue.RemoveDuck(_Duck);
    }

    private bool BurgerComplete = false;

    public void AddToPlate(Item item)
    {

        if (BurgerComplete)
            return;
        

        Image food;
        switch(item.FType)
        {
            case FoodType.Cheese:
                FoodTypeColorCode = 4;
                break;
            case FoodType.Meat:
                FoodTypeColorCode = 0;
                break;
            case FoodType.Tomato:
                FoodTypeColorCode = 12;
                break;
            case FoodType.Vege:
                FoodTypeColorCode = 8;
                break;
        }
        //Meat, Cheese, Vege, Tomato

        switch (item.Level)
        {
            case 0:
                food = GameObject.Instantiate(Food[FoodTypeColorCode].gameObject).GetComponent<Image>();
                break;
            case 1:
                food = GameObject.Instantiate(Food[FoodTypeColorCode + 1].gameObject).GetComponent<Image>();
                break;
            case 2:
                food = GameObject.Instantiate(Food[FoodTypeColorCode + 2].gameObject).GetComponent<Image>();
                break;
            case 3:
                food = GameObject.Instantiate(Food[FoodTypeColorCode + 3].gameObject).GetComponent<Image>();
                break;
            default:
                food = GameObject.Instantiate(Food[FoodTypeColorCode + 3].gameObject).GetComponent<Image>();
                break;
        }
        food.rectTransform.SetParent(BurgerRecivedObj.transform);

        food.rectTransform.anchoredPosition = new Vector2(0, ItemsOnPlateOffset);
        PlateList.Add(food);
        ItemsOnPlateOffset += 25;
        int childrenCount = BurgerRecivedObj.GetComponentsInChildren<Image>().Length;

        if (childrenCount == OrderedItemsCount)
        {
           BurgerComplete = true;
           AddLoafToPlate(BurgerTop, new Vector2(0, ItemsOnPlateOffset + 20));
        }
    }

    public void AddLoafToPlate(Image loaf, Vector2 offset)
    {
        Image img = GameObject.Instantiate(loaf.gameObject).GetComponent<Image>();
        img.rectTransform.SetParent(Plate.transform);
        img.rectTransform.anchoredPosition = offset;
        ItemsOnPlateOffset = 10;
        PlateList.Add(img);
    }

    // Update is called once per frame
    void Update()
    {

    }

	#region IObjectDropHandler implementation

	public void HandleDrop (GameObject obj)
	{
		Item it = obj.GetComponent<Item>();
		if(it != null)
		{
			AddToPlate(it);
            Destroy(obj);
        }
		Debug.Log("Drop shit on plate");
	}

	#endregion
}

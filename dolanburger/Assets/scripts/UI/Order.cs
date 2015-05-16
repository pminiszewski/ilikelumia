using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Order : MonoBehaviour
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

    public Image LoafUp;
    public Image LoafDown;
    public Image Foodtype;

    public Image BurgerBottom;

    public List<GameObject> Children;
    public List<Image> PlateList;

    private int ItemsOnPlateOffset;

    // Use this for initialization
    void Start()
    {
        for(int i = 0; i < ColorCode.Length; i++)
        {
            Colors.Add(hexToColor(ColorCode[i]));
        }
    }

    public static Color hexToColor(string hex)
    {
        byte a = 255;
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

        return new Color32(r, g, b, a);
    }

    public void CreateOrder(Burger burger)
    {
        BurgerOrdered = burger;
        AddLoafToPlate(BurgerBottom, burger.Items.Count);
        BurgerReceived.gameObject.SetActive(true);

        for (int i = -1; i < burger.Items.Count + 1; i++)
        {
            Image food;
            if (i == -1)
            {
                food = GameObject.Instantiate(LoafDown.gameObject).GetComponent<Image>();
                food.rectTransform.SetParent(OrderSign.transform);
                Children.Add(food.gameObject);
                continue;
            }
            else if (i == burger.Items.Count)
            {
                food = GameObject.Instantiate(LoafUp.gameObject).GetComponent<Image>();
                food.rectTransform.SetParent(OrderSign.transform);
                Children.Add(food.gameObject);
                continue;
            }

            food = GameObject.Instantiate(Foodtype.gameObject).GetComponent<Image>();

            switch (burger.Items[i].FType)
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

            switch (burger.Items[i].Level)
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
		List<Item> r = BurgerReceived.Items;
		if(o.Count != r.Count)
		{
			return false;
		}
        return false;


    }
    public void OrderComplete()
    {
        for (int i = 0; i < Children.Count; i++)
        {
            GameObject.Destroy(Children[i]);
        }
        for (int i = 0; i < PlateList.Count; i++)
        {
            GameObject.Destroy(PlateList[i]);
        }
        OrderSign.gameObject.SetActive(false);
        BurgerReceived.gameObject.SetActive(false);
        Free = true;
    }

    public void AddToPlate(Item item)
    {

        ItemsOnPlateOffset += 20;
    }

    public void AddLoafToPlate(Image loaf, int empty)
    {
        Image img = GameObject.Instantiate(loaf.gameObject).GetComponent<Image>();
        img.rectTransform.SetParent(Plate.transform);
        img.rectTransform.anchoredPosition = Vector2.zero;
        ItemsOnPlateOffset = 20;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

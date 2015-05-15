using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Order : MonoBehaviour
{
    public bool Free = true;
    public GameObject Plate;
    public GameObject OrderSign;

    public Burger OrderedBurger;
    public Burger OrderedRecived;

    public Image LoafUp;
    public Image LoafDown;
    public Image Meat;
    public Image Tomato;
    public Image Cheese;
    public Image Vege;

    public List<GameObject> Children;

    // Use this for initialization
    void Start()
    {

    }

    public void CreateOrder(Burger burger)
    {
        OrderedBurger = burger;
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

            switch (burger.Items[i].FType)
            {
                case FoodType.Cheese:
                    food = GameObject.Instantiate(Cheese.gameObject).GetComponent<Image>();
                    break;
                case FoodType.Meat:
                    food = GameObject.Instantiate(Meat.gameObject).GetComponent<Image>();
                    break;
                case FoodType.Tomato:
                    food = GameObject.Instantiate(Tomato.gameObject).GetComponent<Image>();
                    break;
                case FoodType.Vege:
                    food = GameObject.Instantiate(Vege.gameObject).GetComponent<Image>();
                    break;
                default:
                    food = GameObject.Instantiate(Vege.gameObject).GetComponent<Image>();
                    break;
            }

            Color c = food.color;

            switch (burger.Items[i].Level)
            {
                case 0:
                    c.b *= 0.5f;
                    c.r *= 0.5f;
                    c.g *= 0.5f;
                    break;
                case 1:
                    c.b *= 1f;
                    c.r *= 1f;
                    c.g *= 1f;
                    break;
                case 2:
                    c.b *= 1.4f;
                    c.r *= 1.4f;
                    c.g *= 1.4f;
                    break;
                case 3:
                    c.b = 1.0f;
                    c.r = 1.0f;
                    c.g = 1.0f;
                    break;
            }
            food.rectTransform.SetParent(OrderSign.transform);
            Children.Add(food.gameObject);
        }

        this.gameObject.SetActive(true);

        Free = false;
        //return this;
    }

    public void OrderComplete()
    {
        for (int i = 0; i < Children.Count; i++)
        {
            GameObject.Destroy(Children[i]);
        }
        this.gameObject.SetActive(false);
        Free = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

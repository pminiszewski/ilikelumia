using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Order : MonoBehaviour
{
    public Image Meat;
    public Image Tomato;
    public Image Cheese;
    public Image Vege;


    // Use this for initialization
    void Start ()
    {
	
	}

    public void CreateOrder(Burger burger)
    {

        for(int i = 0; i < burger.Items.Count; i++)
        {
            Image food = Meat;

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
            food.transform.parent = this.transform;
        }


        this.gameObject.SetActive(true);

        //return this;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class Counter : MonoBehaviour
{
    public List<Order> OrderList;

	// Use this for initialization
	void Start ()
    {
    }

    public void AddOrder(Duck duck)
    {
        for(int i = 0; i < 3; i++)
        {
            if (OrderList[i].Free)
            {
                OrderList[i].CreateOrder(duck, i);
                break;
            }
        }
    }

    public void OrderComplete(Order order)
    {
        order.OrderComplete();
    }

    public void ShowOrder()
    {

    }

	// Update is called once per frame
	void Update ()
    {
	
	}


}

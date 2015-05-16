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
        AddOrder(GrillTest.CreateRandomBurger());
        AddOrder(GrillTest.CreateRandomBurger());
        AddOrder(GrillTest.CreateRandomBurger());

    }

    public void AddOrder(Burger newOrder)
    {
        for(int i = 0; i < 3; i++)
        {
            if (OrderList[i].Free)
            {
                OrderList[i].CreateOrder(newOrder);
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

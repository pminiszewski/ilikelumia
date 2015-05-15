using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Counter : MonoBehaviour
{
    public List<Order> OrderList;
    int _OrderCount;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
    public void AddOrder(Burger newOrder)
    {

        OrderList[_OrderCount].CreateOrder(newOrder);
        _OrderCount++;
    }

    public void OrderComplete(Burger order)
    {
    }

    public void ShowOrder()
    {

    }

	// Update is called once per frame
	void Update ()
    {
	
	}


}

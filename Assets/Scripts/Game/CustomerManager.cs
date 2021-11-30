using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public static int preloadedCustomers = 15;

    private bool hasCustomer;
    public static List<Customer> customers = new List<Customer>();

    public static void PopulateCustomers()
    {
        while(customers.Count < preloadedCustomers)
        {
            customers.Add(Customer.GenerateCustomer());
        }
    }
}

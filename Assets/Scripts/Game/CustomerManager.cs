using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public static int preloadedCustomers = 15;
    public static bool hasCustomer = false;

    public static List<Customer> customers = new List<Customer>();
    public static Customer currentCustomer = null;

    public static void PopulateCustomers()
    {
        while(customers.Count < preloadedCustomers)
        {
            customers.Add(Customer.GenerateCustomer());
        }
    }

    public static void StartCustomerSpawn()
    {
        PopulateCustomers();

        if(hasCustomer == false)
            ShowNextCustomer();
    }

    public static void StopCustomerSpawn()
    {
        customers.Clear();
        currentCustomer = null;
        hasCustomer = false;
    }

    private static Customer ChooseNextCustomer()
    {
        int i = GameController.r.Next(customers.Count);
        return customers[i];
    }

    private static void ShowNextCustomer()
    {
        Customer c = ChooseNextCustomer();
        currentCustomer = c;

        string sprite = c.GetSprite();
        //assign sprites to customer prefab
        //make customer prefab visible
        hasCustomer = true;
    }

    private static void HideThisCustomer()
    {
        //hide customer prefab
        if(currentCustomer != null)
        {
            customers.Remove(currentCustomer);
            currentCustomer = null;
        }
        hasCustomer = false;
    }
}

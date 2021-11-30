using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{


    void Start()
    {
        CustomerManager.PopulateCustomers();
        foreach(Customer c in CustomerManager.customers)
        {
            Debug.Log(c.GetCustomerName() + ", " + c.GetOrder().GetBread());
        }
    }

    void Update()
    {
        
    }
}

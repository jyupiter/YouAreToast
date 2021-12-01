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

        //TODO: delay first customer's appearance
        if(hasCustomer == false)
            ShowNextCustomer();
    }

    public static void StopCustomerSpawn()
    {
        NotifyObservers("ending the day... all customers leaving");

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
        NotifyObservers("next customer incoming (hopefully)");

        Customer c = ChooseNextCustomer();
        currentCustomer = c;

        List<int> spritesToUse = c.GetSpritesToUse();
        List<Sprite> spritesToAssign = Customer.IntsToSprites(c.GetSpritesToUse(), FileIO.GetSpriteLists());
        //assign sprites to customer prefab
        //make customer prefab visible
        hasCustomer = true;
    }

    private static void HideThisCustomer()
    {
        NotifyObservers("this customer is leaving now");

        //hide customer prefab
        if(currentCustomer != null)
        {
            customers.Remove(currentCustomer);
            currentCustomer = null;
        }
        hasCustomer = false;
    }

    #region event system

    private delegate void Notify(string msg);
    private static event Notify NotifyEvent;

    public static void RegisterObserver(IObserver aObserver)
    {
        NotifyEvent += aObserver.Notify;
    }

    public static void UnregisterObserver(IObserver aObserver)
    {
        NotifyEvent -= aObserver.Notify;
    }

    private static void NotifyObservers(string aMsg)
    {
        NotifyEvent(aMsg);
    }

    #endregion
}

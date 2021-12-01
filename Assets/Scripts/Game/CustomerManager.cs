using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomerManager : MonoBehaviour
{
    CustomerManager cm;

    public static int preloadedCustomers = 15;
    public static bool hasCustomer = false;

    public static List<Customer> customers = new List<Customer>();
    public static Customer currentCustomer = null;

    public GameObject customerSpawnPosition;
    public GameObject customerPrefab;
    public static GameObject currentCustomerObject;

    public GameObject customerInfoContainer;
    public TextMeshProUGUI displayName;
    public TextMeshProUGUI displayPatience;

    void Awake()
    {
        cm = gameObject.GetComponent<CustomerManager>();
    }

    public static void PopulateCustomers()
    {
        while(customers.Count < preloadedCustomers)
        {
            customers.Add(Customer.GenerateCustomer());
        }
    }

    public void StartCustomerSpawn()
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

        currentCustomerObject.SetActive(false);
        currentCustomerObject = null;
    }

    private Customer ChooseNextCustomer()
    {
        int i = GameController.r.Next(customers.Count);
        return customers[i];
    }

    private void ShowNextCustomer()
    {
        NotifyObservers("next customer incoming (hopefully)");

        Customer c = ChooseNextCustomer();
        currentCustomer = c;

        print(Patience.currPatience);

        displayName.text = c.GetCustomerName();
        displayPatience.text = Patience.currPatience.ToString();

        List<int> spritesToUse = c.GetSpritesToUse();
        List<Sprite> spritesToAssign = Customer.IntsToSprites(spritesToUse, FileIO.GetSpriteLists());

        if(currentCustomerObject == null)
        {
            currentCustomerObject =
                Instantiate
                (
                    cm.customerPrefab,
                    cm.customerSpawnPosition.transform.position,
                    Quaternion.identity
                );
            currentCustomerObject.SetActive(false);
        }

        SpriteRenderer[] parts = currentCustomerObject.GetComponentsInChildren<SpriteRenderer>();
        for(int i = 0; i < parts.Length; i++)
        {
            parts[i].sprite = spritesToAssign[i];
        }

        currentCustomerObject.SetActive(true);
        hasCustomer = true;
    }

    private static void HideThisCustomer()
    {
        NotifyObservers("this customer is leaving now");

        currentCustomerObject.SetActive(false);

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

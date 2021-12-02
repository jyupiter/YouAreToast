using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomerManager : MonoBehaviour
{
    CustomerManager cm;
    SandwichHandler sandwichHandler;

    public static int preloadedCustomers = 15;
    public static bool hasCustomer = false;

    public static List<Customer> customers = new List<Customer>();
    public static Customer currentCustomer = null;

    public GameObject customerSpawnPosition;
    public GameObject customerPrefab;
    public static GameObject currentCustomerObject;

    public GameObject customerInfoContainer;
    public TextMeshProUGUI displayName;
    public GameObject displayBread, displayTopping1, displayTopping2, displayTopping3, displayTopping4, displayTopping5;
    public Slider currPatienceBar;


    void Awake()
    {
        cm = gameObject.GetComponent<CustomerManager>();
        sandwichHandler = GameObject.Find("Grill Station").GetComponent<SandwichHandler>();
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

        displayName.text = c.GetCustomerName();
        sandwichHandler.UpdateBreadSprite(c.GetOrder(), displayBread);
        for (int i = 0; i < c.GetOrder().GetToppings().Count; i++)
        {
            //displayTopping1.GetComponent<SpriteRenderer>().sprite = c.GetOrder().GetToppings();
        }

        List<int> spritesToUse = c.GetSpritesToUse();
        List<Sprite> spritesToAssign = Customer.IntsToSprites(spritesToUse, FileIO.GetCustomerSpriteLists());

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

        UpdatePatienceText();

        SpriteRenderer[] parts = currentCustomerObject.GetComponentsInChildren<SpriteRenderer>();
        for(int i = 0; i < parts.Length; i++)
        {
            parts[i].sprite = spritesToAssign[i];
        }

        currentCustomerObject.SetActive(true);
        customerInfoContainer.SetActive(true);
        hasCustomer = true;
    }

    public void HideThisCustomer()
    {
        NotifyObservers("this customer is leaving now");

        currentCustomerObject.SetActive(false);
        customerInfoContainer.SetActive(false);

        if (currentCustomer != null)
        {
            customers.Remove(currentCustomer);
            currentCustomer = null;
        }
        hasCustomer = false;
    }

    public void UpdatePatienceText()
    {
        currPatienceBar.maxValue = Patience.randomPatience;
        currPatienceBar.value = Patience.currPatience;
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

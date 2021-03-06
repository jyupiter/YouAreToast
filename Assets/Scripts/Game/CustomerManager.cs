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

    public Score score;

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
    public List<GameObject> toppingGameObjects;
    public GameObject displayBreadKitchen, displayTopping1Kitchen, displayTopping2Kitchen, displayTopping3Kitchen, displayTopping4Kitchen, displayTopping5Kitchen;
    public List<GameObject> toppingGameObjectsKitchen;
    public Slider currPatienceBar;

    void Awake()
    {
        cm = gameObject.GetComponent<CustomerManager>();
        PatienceStates.cm = this;
        sandwichHandler = GameObject.Find("Grill Station").GetComponent<SandwichHandler>();
    }

    public static void PopulateCustomers()
    {
        while(customers.Count < preloadedCustomers)
        {
            customers.Add(Customer.GenerateCustomer());
        }
    }

    private delegate void AnonymousMethod();
    IEnumerator coroutine = null;

    IEnumerator DoWithWait(float time, AnonymousMethod anon)
    {
        yield return new WaitForSeconds(time);
        AnonymousMethod toRun = anon;
        toRun();
        StopCoroutine(coroutine);
    }

    public void StartCustomerSpawn()
    {
        PopulateCustomers();
        coroutine = DoWithWait(0f, delegate()
        {
            if(hasCustomer == false && Level.dayHasEnded == false)
                ShowNextCustomer();
        });
        StartCoroutine(coroutine);
    }

    public void StopCustomerSpawn()
    {
        NotifyObservers("ending the day... all customers leaving");

        currentCustomer = null;
        hasCustomer = false;

        customers.Clear();

        currentCustomerObject.SetActive(false);
        //currentCustomerObject = null;

        score.UpdateFinalScore();

        sandwichHandler.Reset();
    }

    private Customer ChooseNextCustomer()
    {
        int i = GameController.r.Next(customers.Count);
        return customers[i];
    }

    private void ShowNextCustomer()
    {
        NotifyObservers("next customer is here");

        Customer c = ChooseNextCustomer();
        currentCustomer = c;

        displayName.text = c.GetCustomerName();

        sandwichHandler.UpdateBreadSprite(c.GetOrder(), displayBread);
        sandwichHandler.UpdateToppingsSprites(c.GetOrder(), toppingGameObjects);

        sandwichHandler.UpdateBreadSprite(c.GetOrder(), displayBreadKitchen);
        sandwichHandler.UpdateToppingsSprites(c.GetOrder(), toppingGameObjectsKitchen);

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
        NotifyObservers("this customer is leaving");

        Destroy(currentCustomerObject);
        currentCustomerObject = null;
        customerInfoContainer.SetActive(false);

        if (currentCustomer != null)
        {
            customers.Remove(currentCustomer);
            currentCustomer = null;
        }
        hasCustomer = false;
        sandwichHandler.Reset();

        if(Level.dayHasEnded == false)
        {
            coroutine = DoWithWait(3f, delegate ()
            {
                ShowNextCustomer();
            });
            StartCoroutine(coroutine);
        }
    }

    public void UpdatePatienceText()
    {
        currPatienceBar.maxValue = Patience.randomPatience;
        currPatienceBar.value = Patience.currPatience;
    }

    #region event system

    private delegate void Notify(string msg);
    private static event Notify NotifyEvent;

    public static void RegisterNotificationObserver(IOnReceiveNotificationEvent aObserver)
    {
        NotifyEvent += aObserver.UpdateNotification;
    }

    public static void UnregisterObserver(IOnReceiveNotificationEvent aObserver)
    {
        NotifyEvent -= aObserver.UpdateNotification;
    }

    private static void NotifyObservers(string aMsg)
    {
        NotifyEvent(aMsg);
    }

    #endregion
}

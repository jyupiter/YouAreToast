using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Order;

public class SandwichHandler : MonoBehaviour, IOnReceiveNotificationEvent, IOnSandwichChangeStateEvent
{
    [HideInInspector] public Sandwich sandwich = null;
    public SandwichState sandwichState = SandwichState.fresh;
    public Toaster toaster;

    public GameObject prefab;

    [HideInInspector] public GameObject sandwichObject;
    public GameObject toasterPositionMarker;
    public GameObject platePositionMarker;

    #region instantiate sandwich

    public void StartBriocheSandwich()
    {
        if(sandwich != null)
            return;
        sandwich =
            new Sandwich
            (
                CustomerManager.currentCustomer.GetOrder(),
                Bread.brioche,
                ToastLevel.untoasted
            );
        UpdateNotification("started brioche sandwich");
        StartToaster();
    }

    public void StartEnglishMuffinSandwich()
    {
        if(sandwich != null)
            return;
        sandwich =
            new Sandwich
            (
                CustomerManager.currentCustomer.GetOrder(),
                Bread.english_muffin,
                ToastLevel.untoasted
            );
        UpdateNotification("started english muffin sandwich");
        StartToaster();
    }

    public void StartBagelSandwich()
    {
        if(sandwich != null)
            return;
        sandwich =
            new Sandwich
            (
                CustomerManager.currentCustomer.GetOrder(),
                Bread.bagel,
                ToastLevel.untoasted
            );
        UpdateNotification("started bagel sandwich");
        StartToaster();
    }

    #endregion

    public bool StartToaster()
    {
        sandwichObject =
            Instantiate
            (
                prefab,
                toasterPositionMarker.transform.position,
                Quaternion.identity
            );
        UpdateBreadSprite(sandwich, sandwichObject);
        toaster.StartToasting(sandwich);
        sandwichState = SandwichState.toasted;
        return true;
    }

    public bool MoveBread()
    {
        toaster.StopToasting();
        sandwichObject.transform.position = platePositionMarker.transform.position;
        sandwichState = SandwichState.complete;
        return true;
    }

    public void SubmitSandwich()
    {
        if(sandwichObject == null)
            return;

        UpdateSandwichState(this);
        Reset();
    }

    public void ClearSandwichToppings()
    {
        sandwich.ClearToppings();

        List<GameObject> children = new List<GameObject>();

        foreach(Transform t in sandwichObject.transform)
            children.Add(t.gameObject);

        UpdateToppingsSprites(sandwich, children);
    }

    public void Reset()
    {
        sandwich = null;
        sandwichState = SandwichState.fresh;
        Destroy(sandwichObject);
        sandwichObject = null;
    }

    #region update sprites

    public void UpdateBreadSprite(Container container, GameObject targetGameObject)
    {
        Bread bread = container.GetBread();
        ToastLevel toastLevel = container.GetToastLevel();
        Sprite[] breadSprites;

        switch(bread)
        {
            case Bread.brioche:
                breadSprites = FileIO.GetBriocheSprites();
                break;
            case Bread.english_muffin:
                breadSprites = FileIO.GetEnglishMuffinSprites();
                break;
            case Bread.bagel:
                breadSprites = FileIO.GetBagelSprites();
                break;
            default:
                breadSprites = FileIO.GetBagelSprites();
                break;
        }

        int levelInt = (int)Convert.ChangeType(toastLevel, toastLevel.GetTypeCode());
        targetGameObject.GetComponent<SpriteRenderer>().sprite = breadSprites[levelInt];
    }

    public void UpdateToppingsSprites(Container container, List<GameObject> targetGameObjectList)
    {
        Stack<Topping> toppings = container.GetToppings();
        Sprite[] toppingSprites = FileIO.GetToppingsSprites(toppings, targetGameObjectList.Count);

        for(int i = 0; i < targetGameObjectList.Count; i++)
        {
            targetGameObjectList[i].GetComponent<SpriteRenderer>().sprite = toppingSprites[i];
        }
    }

    #endregion

    #region event system

    private delegate void NotifyMessage(string msg);
    private static event NotifyMessage NotifyMessageEvent;

    public static void RegisterNotificationObserver(IOnReceiveNotificationEvent aObserver)
    {
        NotifyMessageEvent += aObserver.UpdateNotification;
    }

    public static void UnregisterNotificationObserver(IOnReceiveNotificationEvent aObserver)
    {
        NotifyMessageEvent -= aObserver.UpdateNotification;
    }

    public void UpdateNotification(string aMsg)
    {
        if(sandwichObject != null)
            UpdateBreadSprite(sandwich, sandwichObject);
        NotifyMessageEvent(aMsg);
    }

    private delegate void NotifyState(SandwichHandler sandwichHandler);
    private static event NotifyState NotifyStateEvent;

    public static void RegisterStateObserver(IOnSandwichChangeStateEvent aObserver)
    {
        NotifyStateEvent += aObserver.UpdateSandwichState;
    }

    public static void UnregisterStateObserver(IOnSandwichChangeStateEvent aObserver)
    {
        NotifyStateEvent -= aObserver.UpdateSandwichState;
    }

    public void UpdateSandwichState(SandwichHandler sandwichHandler)
    {
        NotifyStateEvent(this);
    }

    #endregion

    public enum SandwichState
    {
        fresh,
        toasted,
        complete
    }
}

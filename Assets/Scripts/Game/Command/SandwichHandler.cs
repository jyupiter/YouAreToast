using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Order;

public class SandwichHandler : MonoBehaviour, IObserver
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
        Notify("started brioche sandwich");
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
        Notify("started english muffin sandwich");
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
        Notify("started bagel sandwich");
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
        return true;
    }

    public bool SubmitSandwich()
    {
        //TODO: do scoring in score.cs
        ResetSandwichHandler();
        return true;
    }

    public void ClearSandwichData()
    {
        sandwich.ClearToppings();

        List<GameObject> children = new List<GameObject>();

        foreach(Transform t in sandwichObject.transform)
            children.Add(t.gameObject);

        UpdateToppingsSprites(sandwich, children);
    }

    public void ResetSandwichHandler()
    {
        sandwich = null;
        sandwichObject = null;
        Destroy(sandwichObject);
        sandwichState = SandwichState.fresh;
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
    private static event NotifyMessage NotifyEvent;

    public static void RegisterObserver(IObserver aObserver)
    {
        NotifyEvent += aObserver.Notify;
    }

    public static void UnregisterObserver(IObserver aObserver)
    {
        NotifyEvent -= aObserver.Notify;
    }

    public void Notify(string aMsg)
    {
        NotifyEvent(aMsg);
    }

    #endregion

    public enum SandwichState
    {
        fresh,
        toasted,
        complete
    }
}

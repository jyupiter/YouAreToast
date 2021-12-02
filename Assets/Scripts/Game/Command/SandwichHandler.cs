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
        NotifyObservers("started brioche sandwich");
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
        NotifyObservers("started english muffin sandwich");
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
        NotifyObservers("started bagel sandwich");
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
        UpdateBreadSprite(sandwich);
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

    //TODO: add method to mark sandwich as complete

    public bool SubmitSandwich()
    {
        //TODO: do something in Level.cs
        Destroy(sandwichObject);
        sandwichState = SandwichState.fresh;
        return true;
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

    void IObserver.Notify(string aMsg)
    {
        UpdateBreadSprite(sandwich);
    }

    public void UpdateBreadSprite(Sandwich sandwich)
    {
        Bread bread = sandwich.GetBread();
        ToastLevel toastLevel = sandwich.GetToastLevel();
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
        sandwichObject.GetComponent<SpriteRenderer>().sprite = breadSprites[levelInt];
    }

    #endregion

    #region COMMAND FUCKERY

    /*

    //script references

    public ICommand addTopping { get; set; }
    public ICommand removeTopping { get; set; }
    public ICommand resetToppings { get; set; }

    public Stack<ICommand> commands = new Stack<ICommand>();

    public void Start()
    {
        addTopping = new CAddTopping(this, sandwich);
        removeTopping = new CRemoveTopping(sandwich);
        resetToppings = new CResetToppings(sandwich);
    }

    public void Update()
    {
        // if(condition){ commandInput.Function; }
        // if(condition){commandInput2.Function;}
    }

    */
    #endregion

    public enum SandwichState
    {
        fresh,
        toasted,
        complete
    }
}

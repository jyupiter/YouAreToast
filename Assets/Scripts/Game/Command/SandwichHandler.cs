using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Order;

public class SandwichHandler : MonoBehaviour
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

    public bool StartToaster() // require player input. mouse button 0.
    {
        sandwichState = SandwichState.toasted;
        sandwichObject =
            Instantiate
            (
                prefab,
                toasterPositionMarker.transform.position,
                Quaternion.identity
            );
        toaster.StartToasting(sandwich);
        return true;
    }

    public bool MoveBread() // player input.
    {
        sandwichState = SandwichState.complete;
        toaster.StopToasting();
        sandwichObject.transform.position = platePositionMarker.transform.position;
        return true;
    }

    public bool SubmitSandwich()
    {
        sandwichState = SandwichState.fresh;
        //TODO: do something in Level.cs
        Destroy(sandwichObject);
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

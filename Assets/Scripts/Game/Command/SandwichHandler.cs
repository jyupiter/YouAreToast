using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Order;

public class SandwichHandler : MonoBehaviour
{
    private Sandwich sandwich = null;
    Toaster toaster = new Toaster();

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
    }

    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Toaster"))
        {
            toaster.StartToasting(sandwich);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Toaster"))
        {
            toaster.StopToasting();
        }
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
}

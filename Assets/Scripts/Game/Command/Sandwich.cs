using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Order;

public class Sandwich : Container
{
    private Order order = null;

    public Sandwich(Order order, Bread bread, ToastLevel toastLevel)
    {
        this.order = order;
        this.bread = bread;
        this.toastLevel = toastLevel;
    }

    public bool AddTopping(Topping topping)
    {
        toppings.Push(topping);

        if(order.GetToppings().Contains(topping))
            return true;
        return false;
    }

    public Topping RemoveTopping()
    {
        return toppings.Pop();
    }

    public bool IncreaseToastLevel()
    {
        bool hasNextState = false;
        switch(toastLevel)
        {
            case ToastLevel.untoasted:
                toastLevel = ToastLevel.golden;
                NotifyObservers("golded");
                hasNextState = true;
                break;
            case ToastLevel.golden:
                toastLevel = ToastLevel.crispy;
                NotifyObservers("crispy");
                hasNextState = true;
                break;
            case ToastLevel.crispy:
                toastLevel = ToastLevel.charred;
                NotifyObservers("charred");
                hasNextState = true;
                break;
            case ToastLevel.charred:
                break;
            default:
                break;
        }
        return hasNextState;
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

    #region getter setter

    public void SetCurrentToppings(Stack<Topping> currentToppings)
    {
        this.toppings = currentToppings;
    }

    #endregion
}

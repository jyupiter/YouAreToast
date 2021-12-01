using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Order;

public class Sandwich
{
    private Order order = null;

    private Bread bread = Bread.bagel;
    private ToastLevel toastLevel = ToastLevel.untoasted;

    private Stack<Topping> currentToppings = new Stack<Topping>();

    public Sandwich(Order order, Bread bread, ToastLevel toastLevel)
    {
        this.order = order;
        this.bread = bread;
        this.toastLevel = toastLevel;
    }

    public bool AddTopping(Topping topping)
    {
        currentToppings.Push(topping);

        if(order.GetToppings().Contains(topping))
            return true;
        return false;
    }

    public Topping RemoveTopping()
    {
        return currentToppings.Pop();
    }

    public bool IncreaseToastLevel()
    {
        bool hasNextState = false;
        switch(toastLevel)
        {
            case ToastLevel.untoasted:
                toastLevel = ToastLevel.golden;
                NotifyObservers("toast is now golden");
                hasNextState = true;
                break;
            case ToastLevel.golden:
                toastLevel = ToastLevel.crispy;
                NotifyObservers("toast is now crispy");
                hasNextState = true;
                break;
            case ToastLevel.crispy:
                toastLevel = ToastLevel.charred;
                NotifyObservers("toast is now charred");
                hasNextState = true;
                break;
            case ToastLevel.charred:
                NotifyObservers("you can't toast this further");
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

    public Stack<Topping> GetCurrentToppings()
    {
        return currentToppings;
    }

    public void SetCurrentToppings(Stack<Topping> currentToppings)
    {
        this.currentToppings = currentToppings;
    }

    #endregion
}

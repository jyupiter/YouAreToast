using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Order;

public abstract class Container
{
    protected Bread bread = Bread.bagel;
    protected ToastLevel toastLevel = ToastLevel.untoasted;
    protected Stack<Topping> toppings;

    public Container() { }

    public Container(Bread bread, ToastLevel toastLevel)
    {
        bread = Bread.bagel;
        toastLevel = ToastLevel.untoasted;
        toppings = new Stack<Topping>();
    }

    public Bread GetBread()
    {
        return bread;
    }

    public void SetBread(Bread bread)
    {
        this.bread = bread;
    }

    public ToastLevel GetToastLevel()
    {
        return toastLevel;
    }

    public void SetToastLevel(ToastLevel toastLevel)
    {
        this.toastLevel = toastLevel;
    }

    public Stack<Topping> GetToppings()
    {
        return toppings;
    }
}

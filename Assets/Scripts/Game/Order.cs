using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order
{

    [SerializeField] private Bread bread;
    [SerializeField] private ToastLevel toastLevel;

    public static int minToppings = 1;
    public static int maxToppings = 5;

    [SerializeField] private List<Topping> toppings;
    private Customer customer;

    public Order()
    {
        bread = Bread.bagel;
        toastLevel = ToastLevel.untoasted;
        toppings = new List<Topping>();
        customer = null;
    }

    public Order(Bread bread, ToastLevel toastLevel, List<Topping> toppings)
    {
        this.bread = bread;
        this.toastLevel = toastLevel;
        this.toppings = toppings;
        customer = null;
    }

    public static Order GenerateOrder()
    {
        Array values;

        Bread chosenBread;
        List<Topping> chosenToppings = new List<Topping>();
        Topping chosentopping;
        ToastLevel chosenToastLevel;

        values = Enum.GetValues(typeof(Bread));
        chosenBread = (Bread)values.GetValue(GameController.r.Next(values.Length));

        int numberOfToppings = GameController.r.Next(minToppings, maxToppings);

        for(int i = 0; i < numberOfToppings; i++)
        {
            values = Enum.GetValues(typeof(Topping));
            chosentopping = (Topping)values.GetValue(GameController.r.Next(values.Length));

            chosenToppings.Add(chosentopping);
        }

        values = Enum.GetValues(typeof(ToastLevel));
        chosenToastLevel = (ToastLevel)values.GetValue(GameController.r.Next(values.Length));

        return new Order(chosenBread, chosenToastLevel, chosenToppings);
    }

    public void SetCustomer(Customer customer)
    {
        this.customer = customer;
    }

    public Bread GetBread()
    {
        return bread;
    }

    public ToastLevel GetToastLevel()
    {
        return toastLevel;
    }

    public List<Topping> GetToppings()
    {
        return toppings;
    }

    #region enums

    public enum Bread
    {
        brioche,
        english_muffin,
        bagel
    }

    public enum ToastLevel
    {
        untoasted,
        golden,
        crispy,
        charred
    }

    public enum Topping
    {
        cheese,
        egg,
        avocado,
        bacon,
        lettuce,
        tomato,
        mayonaise,
        ketchup,
        bbq_sauce
    }

    #endregion
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Order;
using static SandwichHandler;

public class Score : MonoBehaviour, IOnSandwichChangeStateEvent
{
    public static int score = 0;
    public TextMeshProUGUI finalScore;

    [HideInInspector] public CustomerManager cm;

    private void Awake()
    {
        cm = GameObject.Find("Scripts").GetComponent<CustomerManager>();
    }

    public void UpdateSandwichState(SandwichHandler sandwichHandler)
    {
        if(sandwichHandler.sandwichState == SandwichState.complete)
        {
            UpdateScore(sandwichHandler.sandwich);
            sandwichHandler.Reset();
            //Customer leaves after receiving sandwich
            cm.HideThisCustomer();
        }
    }

    public void UpdateFinalScore()
    {
        //TODO score has been linked but this method is not used anywhere yet
        finalScore.text = score.ToString();
    }

    private void UpdateScore(Sandwich sandwich)
    {
        int result = Calculate(sandwich, CustomerManager.currentCustomer.GetOrder());
        score += result;
    }

    private int Calculate(Sandwich sandwich, Order order)
    {
        int initialScore = 15;
        int bonus = 0;
        int penalty = 0;

        Stack<Topping> sandwichToppings = sandwich.GetToppings();
        Stack<Topping> orderToppings = order.GetToppings();

        Topping[] sandwichToppingArray = sandwichToppings.ToArray();
        Topping[] orderToppingArray = orderToppings.ToArray();

        // sort for comparison
        Array.Sort(sandwichToppingArray);
        Array.Sort(orderToppingArray);

        // correct bread
        if(sandwich.GetBread() == order.GetBread())
            bonus++;
        // correct toastlevel
        if(sandwich.GetToastLevel() == order.GetToastLevel())
            bonus++;

        bool hasAllToppings = true;

        foreach(Topping t in orderToppingArray)
            // if missing any topping
            if(!Array.Exists(sandwichToppingArray, element => element == t))
            {
                hasAllToppings = false;
                penalty++;
            }

        // only if all toppings are there
        if(hasAllToppings == true)
            // correct number of toppings
            if(sandwichToppingArray.Length == orderToppingArray.Length)
                bonus += 5;

        // fewer toppings
        if(sandwichToppingArray.Length < orderToppingArray.Length)
            penalty++;

        int finalScore = initialScore + bonus - penalty;

        return Math.Max(0, finalScore);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patience : MonoBehaviour, ICustomerStates
{
    private float maxPatience = 10f;
    private float patience;
    public void CustomerHappy()
    {
        Debug.Log("Customer is happy");
        //TODO: Happy expressions
        //TODO: When toast is given to customer: Compare product with expectation.
            //If correct order is given, give high tips
            //If wrong order, give small tips
    }
    public void CustomerImpatient()
    {
        Debug.Log("Customer is impatient");
        //TODO: Impatient expression
        //TODO: When toast is given to customer: Compare product with expectation.
            //If correct order is given, give small tips
            //If wrong order, give no tips
    }
    public void CustomerAngry()
    {
        Debug.Log("Customer is angry");
        //TODO: Angry expression
        //TODO: When toast is given to customer: Compare product with expectation.
            //If correct order is given, give no tips
            //If wrong order, dont even pay for the toast.
    }
    private void Start()
    {
        patience = maxPatience;
    }

    private void Update()
    {
        if(patience > 0)
        {
            patience -= 1 * Time.deltaTime;
        }
        else
        {
            patience = 0;
        }
        if (patience <= maxPatience / 3)
        {
            CustomerAngry();
        }
        else if (patience < maxPatience / 3 * 2)
        {
            CustomerImpatient();
        }
        else
        {
            CustomerHappy();
        }
    }
}

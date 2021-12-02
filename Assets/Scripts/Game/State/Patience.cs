using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Patience : MonoBehaviour, ICustomerStates
{
    private int minPatience = 50;
    private int maxPatience = 90;

    private float randomPatience;
    public static float currPatience;

    public SpriteRenderer expression;

    [HideInInspector] public CustomerManager cm;

    public void CustomerHappy()
    {
        expression.sprite = FileIO.GetCustomerSpriteLists()[1][0];
        //TODO: When toast is given to customer: Compare product with expectation.
            //If correct order is given, give high tips
            //If wrong order, give small tips
    }
    public void CustomerImpatient()
    {
        expression.sprite = FileIO.GetCustomerSpriteLists()[1][1];
        //TODO: When toast is given to customer: Compare product with expectation.
        //If correct order is given, give small tips
        //If wrong order, give no tips
    }
    public void CustomerAngry()
    {
        expression.sprite = FileIO.GetCustomerSpriteLists()[1][2];
        //TODO: When toast is given to customer: Compare product with expectation.
        //If correct order is given, give no tips
        //If wrong order, dont even pay for the toast.
    }
    public void CustomerLeave()
    {
        cm.HideThisCustomer();
    }
    public void Awake()
    {
        cm = GameObject.Find("Scripts").GetComponent<CustomerManager>();
        randomPatience = GameController.r.Next(minPatience, maxPatience);
        currPatience = randomPatience;
    }

    private void Update() 
    {
        if(currPatience > 0)
            currPatience -= Time.deltaTime;
        else
            currPatience = 0;
        if (currPatience == 0)
        {
            CustomerLeave();
        }
        else if (currPatience <= randomPatience / 3)
            CustomerAngry();
        else
            if (currPatience < randomPatience / 3 * 2)
                CustomerImpatient();
            else
                CustomerHappy();
    }
}

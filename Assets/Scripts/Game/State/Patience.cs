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

    public void CustomerHappy()
    {
        Debug.Log("Customer is happy");
        expression.sprite = FileIO.GetSpriteLists()[1][0];
        //TODO: When toast is given to customer: Compare product with expectation.
            //If correct order is given, give high tips
            //If wrong order, give small tips
    }
    public void CustomerImpatient()
    {
        Debug.Log("Customer is impatient");
        expression.sprite = FileIO.GetSpriteLists()[1][1];
        //TODO: When toast is given to customer: Compare product with expectation.
        //If correct order is given, give small tips
        //If wrong order, give no tips
    }
    public void CustomerAngry()
    {
        Debug.Log("Customer is angry");
        expression.sprite = FileIO.GetSpriteLists()[1][2];
        //TODO: When toast is given to customer: Compare product with expectation.
        //If correct order is given, give no tips
        //If wrong order, dont even pay for the toast.
    }
    public void Awake()
    {
        randomPatience = GameController.r.Next(minPatience, maxPatience);
        currPatience = randomPatience;
    }

    private void Update()
    {
        if(currPatience > 0)
        {
            currPatience -= 1 * Time.deltaTime;
        }
        else
        {
            currPatience = 0;
        }

        if (currPatience <= randomPatience / 3)
        {
            CustomerAngry();
        }
        else if (currPatience < randomPatience / 3 * 2)
        {
            CustomerImpatient();
        }
        else
        {
            CustomerHappy();
        }
    }
}

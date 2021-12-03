using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatienceStates : MonoBehaviour, ICustomerStates
{
    [HideInInspector] public SpriteRenderer expression;
    public static CustomerManager cm;

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
}

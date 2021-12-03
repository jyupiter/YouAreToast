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
    }

    public void CustomerImpatient()
    {
        expression.sprite = FileIO.GetCustomerSpriteLists()[1][1];
    }

    public void CustomerAngry()
    {
        expression.sprite = FileIO.GetCustomerSpriteLists()[1][2];
    }

    public void CustomerLeave()
    {
        cm.HideThisCustomer();
    }
}

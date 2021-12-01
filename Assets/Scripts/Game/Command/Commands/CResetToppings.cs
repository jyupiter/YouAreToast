using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CResetToppings : MonoBehaviour, ICommand
{
    private Sandwich sandwich;

    public CResetToppings(Sandwich sandwich)
    {
        this.sandwich = sandwich;
    }

    public void Execute()
    {
        throw new System.NotImplementedException();
    }
}

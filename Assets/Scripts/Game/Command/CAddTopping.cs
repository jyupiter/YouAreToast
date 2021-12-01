using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Order;

public class CAddTopping : MonoBehaviour, ICommand
{
    private SandwichHandler sandwichHandler;
    private Sandwich sandwich;

    public CAddTopping(SandwichHandler sandwichHandler, Sandwich sandwich)
    {
        this.sandwichHandler = sandwichHandler;
        this.sandwich = sandwich;
    }

    public void Execute()
    {
        // if(sandwichHandler.relevantScript.Function){

        // SandwichHandler.commands.Push(this);

        //}
    }
}

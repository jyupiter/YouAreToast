using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSubmitSandwich : ICommand
{
    private InputHandler inputHandler;

    public CSubmitSandwich(InputHandler thisScript)
    {
        inputHandler = thisScript;
    }

    public void Execute()
    {
        if(inputHandler.sandwichHandler.SubmitSandwich())
        {
            inputHandler.commands.Push(this);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStartToaster : ICommand
{
    private InputHandler inputHandler;

    public CStartToaster(InputHandler thisScript)
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

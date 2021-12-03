using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitSandwichCommand : ICommand
{
    private InputHandler inputHandler;

    public SubmitSandwichCommand(InputHandler thisScript)
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

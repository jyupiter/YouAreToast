using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBreadCommand : ICommand
{
    private InputHandler inputHandler;

    public MoveBreadCommand(InputHandler thisScript)
    {
        inputHandler = thisScript;
    }

    public void Execute()
    {
        if(inputHandler.sandwichHandler.MoveBread())
        {
            inputHandler.commands.Push(this);
        }
    }
}

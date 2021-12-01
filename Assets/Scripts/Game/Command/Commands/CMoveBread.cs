using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMoveBread : ICommand
{
    private InputHandler inputHandler;

    public CMoveBread(InputHandler thisScript)
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

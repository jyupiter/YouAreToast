using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartToasterCommand : ICommand
{
    //
    [HideInInspector] public InputHandler inputHandler;

    public StartToasterCommand(InputHandler thisScript)
    {
        inputHandler = thisScript;
    }

    public void Execute()
    {
        inputHandler.sandwichHandler.SubmitSandwich();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SandwichHandler;

public class Score : MonoBehaviour, IOnSandwichChangeStateEvent
{
    public void UpdateSandwichState(SandwichState sandwichState)
    {
        if(sandwichState == SandwichState.complete)
        {
            Calculate();
            UpdateScore();
        }
    }

    private void Calculate()
    {

    }

    private void UpdateScore()
    {

    }
}

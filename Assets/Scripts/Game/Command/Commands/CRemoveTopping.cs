using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRemoveTopping : MonoBehaviour, ICommand
{
    private Sandwich sandwich;

    public CRemoveTopping(Sandwich sandwich)
    {
        this.sandwich = sandwich;
    }

    public void Execute()
    {
        throw new System.NotImplementedException();
    }
}

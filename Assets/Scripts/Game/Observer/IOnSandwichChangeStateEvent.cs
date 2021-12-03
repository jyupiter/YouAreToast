using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SandwichHandler;

public interface IOnSandwichChangeStateEvent
{
    void UpdateSandwichState(SandwichHandler sandwichHandler);
}

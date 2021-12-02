using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IToppingCommand
{
    void Execute();
    void Undo();
    void Redo();
}

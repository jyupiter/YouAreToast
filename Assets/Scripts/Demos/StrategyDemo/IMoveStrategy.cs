using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyDemo
{
    public interface IMoveStrategy
    {
        Vector2 GetMoveVector(float dTime, Vector2 mousePos, Vector2 selfPos);
    }
}
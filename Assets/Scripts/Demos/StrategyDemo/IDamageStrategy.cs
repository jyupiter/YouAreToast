using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyDemo
{
    public interface IDamageStrategy
    {
        void SetInitialHp(float initHp);
        float UpdateHp(float dTime);
        Color GetColor();
        void OnClick();
        void OnEnter();
        void OnExit();
        void OnRelease();

    }
}
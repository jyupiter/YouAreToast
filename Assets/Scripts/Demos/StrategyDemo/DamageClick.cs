using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyDemo
{
    public class DamageClick : IDamageStrategy
    {
        private const float dmgAmount = 2f;

        private float hpLeft = 0;

        public void SetInitialHp(float initHp)
        {
            hpLeft = initHp;
        }

        public float UpdateHp(float dTime)
        {
            return hpLeft;
        }

        public Color GetColor() => Color.blue;

        public void OnClick()
        {
            //reduce hp per click
            hpLeft -= dmgAmount;
        }

        public void OnEnter()
        {
            //nothing
        }

        public void OnExit()
        {
            //nothing
        }

        public void OnRelease()
        {
            //nothing
        }
    }
}
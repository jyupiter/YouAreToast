using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyDemo
{
    public class DamageHover : IDamageStrategy
    {
        private const float dmgMult = 3f;

        private float hpLeft = 0;
        private bool isHover = false;

        public void SetInitialHp(float initHp)
        {
            hpLeft = initHp;

            isHover = false;
        }

        public float UpdateHp(float dTime)
        {
            if (isHover)
            {
                //reduce hp while mouse hovered on enemy
                hpLeft -= dTime * dmgMult;
            }

            return hpLeft;
        }

        public Color GetColor() => Color.green;

        public void OnClick()
        {
            //nothing
        }

        public void OnEnter()
        {
            //mouse entered enemy
            isHover = true;
        }

        public void OnExit()
        {
            //mouse left enemy
            isHover = false;
        }

        public void OnRelease()
        {
            //nothing
        }
    }
}
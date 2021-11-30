using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyDemo
{
    public class DamageHold : IDamageStrategy
    {
        private const float dmgMult = 6f;

        private float hpLeft = 0;
        private bool isHold = false;

        public void SetInitialHp(float initHp)
        {
            hpLeft = initHp;

            isHold = false;
        }

        public float UpdateHp(float dTime)
        {
            if (isHold)
            {
                //reduce hp while mouse button held on enemy
                hpLeft -= dTime * dmgMult;
            }

            return hpLeft;
        }

        public Color GetColor() => Color.red;

        public void OnClick()
        {
            //enemy clicked
            isHold = true;
        }

        public void OnEnter()
        {
            //nothing
        }

        public void OnExit()
        {
            //mouse left enemy
            isHold = false;
        }

        public void OnRelease()
        {
            //mouse released
            isHold = false;
        }
    }
}
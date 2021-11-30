using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyDemo
{
    public class MoveFollow : IMoveStrategy
    {
        private const float changeInterval = 1f; //interval between direction set

        private float moveTimer = 1f; //movement timer
        private Vector2 moveDir = new Vector2(); //selected move direction

        public Vector2 GetMoveVector(float dTime, Vector2 mousePos, Vector2 selfPos)
        {
            moveTimer += dTime;

            if (moveTimer > changeInterval)
            {
                moveTimer -= changeInterval;

                //set move direction towards mouse position
                moveDir = mousePos - selfPos;
            }

            return moveDir.normalized * dTime;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyDemo
{
    public class MoveDash : IMoveStrategy
    {
        private const float changeInterval = 1f; //interval to switch between move and stop cycle
        private const float dashMult = 2f; //dash speed

        private float moveTimer = 1f; //movement timer
        private Vector2 moveDir = new Vector2(); //selected move direction
        private bool isMoving = false;

        public Vector2 GetMoveVector(float dTime, Vector2 mousePos, Vector2 selfPos)
        {
            moveTimer += dTime;

            if (moveTimer > changeInterval)
            {
                moveTimer -= changeInterval;

                if (isMoving)
                {
                    //stop moving for a while
                    moveDir = Vector2.zero;
                    isMoving = false;
                } else
                {
                    //select new random direction
                    moveDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

                    //adjust move direction if offscreen
                    if (selfPos.x > 8f) moveDir.x = -Mathf.Abs(moveDir.x);
                    if (selfPos.x < -8f) moveDir.x = Mathf.Abs(moveDir.x);
                    if (selfPos.y > 5f) moveDir.y = -Mathf.Abs(moveDir.y);
                    if (selfPos.y < -5f) moveDir.y = Mathf.Abs(moveDir.y);

                    isMoving = true;
                }
            }

            return moveDir.normalized * dashMult * dTime;
        }
    }
}
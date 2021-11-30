using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyDemo
{
    public class Enemy : MonoBehaviour
    {
        public static int enemyCount = 0;

        [SerializeField]
        private SpriteRenderer hpSprite;
        [SerializeField]
        private SpriteRenderer baseSprite;

        private Camera mainCamera;
        private IMoveStrategy moveStrategy;
        private IDamageStrategy damageStrategy;

        private float currentHp;
        private float maxHp;

        public void Initialize(Camera mainCamera, IMoveStrategy moveStrategy, IDamageStrategy damageStrategy, Color enemyColor, float enemyHp)
        {
            Debug.Log("SPAWN " + moveStrategy + " " + damageStrategy);
            this.mainCamera = mainCamera;

            //set new strategies
            this.moveStrategy = moveStrategy;
            this.damageStrategy = damageStrategy;
            this.damageStrategy.SetInitialHp(enemyHp);

            //set color
            hpSprite.color = enemyColor;
            baseSprite.color = enemyColor * 0.5f;

            //set hp
            maxHp = enemyHp;
            currentHp = maxHp;
            UpdateHpDisplay();

            //add total enemy count
            enemyCount += 1;
        }

        private void Update()
        {
            if (maxHp > 0)
            {
                float dTime = Time.deltaTime;

                //update position
                DoMoveUpdate(dTime);

                //update hp
                DoHpUpdate(dTime);
            }
        }

        public void DoHpUpdate(float dTime)
        {
            //get updated hp from damage strategy
            currentHp = damageStrategy.UpdateHp(dTime);
            UpdateHpDisplay();

            //hp depleted
            if (currentHp <= 0)
            {
                //reduce total enemy count
                enemyCount -= 1;

                //destroy self
                Destroy(this.gameObject);
            }
        }

        public void DoMoveUpdate(float dTime)
        {
            if (moveStrategy != null)
            {
                //get move direction and magnitude from move strategy
                Vector2 moveVector = moveStrategy.GetMoveVector(dTime, mainCamera.ScreenToWorldPoint(Input.mousePosition), this.transform.position);

                //calculate new position
                Vector2 currPos = this.transform.position;
                currPos.x += moveVector.x;
                currPos.y += moveVector.y;

                //set new position
                this.transform.position = currPos;
            }
        }

        private void OnMouseDown()
        {
            damageStrategy?.OnClick();
        }

        private void OnMouseEnter()
        {
            damageStrategy?.OnEnter();
        }

        private void OnMouseExit()
        {
            damageStrategy?.OnExit();
        }

        private void OnMouseUp()
        {
            damageStrategy?.OnRelease();
        }

        private void UpdateHpDisplay()
        {
            //scale circle to show hp left
            float hpPercent = currentHp / maxHp;
            hpSprite.transform.localScale = new Vector2(hpPercent, hpPercent);
        }
    }

}
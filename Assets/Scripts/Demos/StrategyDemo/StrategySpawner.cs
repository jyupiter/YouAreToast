using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyDemo
{
    public class StrategySpawner : MonoBehaviour
    {
        [SerializeField]
        private Camera mainCamera;
        [SerializeField]
        private float spawnInterval = 3f;
        [SerializeField]
        private int spawnMax = 10;
        [SerializeField]
        private GameObject enemyObject;
        [SerializeField]
        private int enemyHp = 10;

        private float spawnTimer;

        // Start is called before the first frame update
        void Start()
        {
            spawnTimer = 0;
        }

        // Update is called once per frame
        void Update()
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer > spawnInterval && Enemy.enemyCount < spawnMax)
            {
                //randomize move strategy
                IMoveStrategy moveStrategy = null;
                switch (Random.Range(0, 3))
                {
                    case 0:
                        moveStrategy = new MoveDash();
                        break;
                    case 1:
                        moveStrategy = new MoveFollow();
                        break;
                    case 2:
                        moveStrategy = new MoveRandom();
                        break;
                }

                //randomize damage strategy
                IDamageStrategy dmgStrategy = null;
                switch (Random.Range(0, 3))
                {
                    case 0:
                        dmgStrategy = new DamageClick();
                        break;
                    case 1:
                        dmgStrategy = new DamageHold();
                        break;
                    case 2:
                        dmgStrategy = new DamageHover();
                        break;
                }

                //spawn enemy
                GameObject newEnemy = Instantiate(enemyObject, new Vector2(Random.Range(-4f, 4f), Random.Range(-3f, 3f)), Quaternion.identity, this.transform);
                newEnemy.GetComponent<Enemy>().Initialize(mainCamera, moveStrategy, dmgStrategy, dmgStrategy.GetColor(), enemyHp);

                //set timer for next spawn
                spawnTimer -= spawnInterval;
            }
        }
    }

}
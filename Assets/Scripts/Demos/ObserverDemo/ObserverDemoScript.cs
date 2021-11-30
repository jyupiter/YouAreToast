using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverDemo
{
    public class ObserverDemoScript : MonoBehaviour
    {
        public Game game;
        public Enemy enemy;
        public Achievement achievement;

        private Player player;

        // Start is called before the first frame update
        void Awake()
        {
            //create objects
            player = new Player(10);
            PlayerManager.MainPlayer = player;

            //register observers to player
            //player.RegisterObserver(game);
            //player.RegisterObserver(enemy);
            //player.RegisterObserver(achievement);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.anyKeyDown && player.CheckPlayerAlive()) {
                //reduce player hp
                player.ReduceHp(2);
            }
        }
    }
}

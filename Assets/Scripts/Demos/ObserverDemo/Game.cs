using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverDemo
{
    public class Game : MonoBehaviour, IObserver
    {
        public GameObject gameOverObj;

        void Start()
        {
            PlayerManager.MainPlayer.RegisterObserver(this);
            gameOverObj.SetActive(false);
        }

        public void ShowGameOver()
        {
            gameOverObj.SetActive(true);
        }

        public void Notify(string aMsg)
        {
            switch (aMsg)
            {
                case "DEAD":
                    ShowGameOver();
                    break;
            }
        }
    }
}
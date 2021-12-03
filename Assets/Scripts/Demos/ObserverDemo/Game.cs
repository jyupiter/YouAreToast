using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverDemo
{
    public class Game : MonoBehaviour, IOnReceiveNotificationEvent
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

        public void UpdateNotification(string aMsg)
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
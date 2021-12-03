using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ObserverDemo
{
    public class Enemy : MonoBehaviour, IOnReceiveNotificationEvent
    {
        public Text enemyLabel;
        private int hitCount = 0;

        void Start()
        {
            PlayerManager.MainPlayer.RegisterObserver(this);
        }

        public void ShowReaction(string aReactionText)
        {
            enemyLabel.text = aReactionText;
        }

        public void UpdateNotification(string aMsg)
        {
            switch (aMsg)
            {
                case "DEAD":
                    ShowReaction("Haha, you're dead!");
                    break;
                default:
                    if (hitCount % 2 == 0)
                        ShowReaction("Rawr!");
                    else
                        ShowReaction("Grrr!");
                    hitCount++;
                    break;
            }
        }
    }
}
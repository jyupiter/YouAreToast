using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ObserverDemo
{
    public class Achievement : MonoBehaviour, IOnReceiveNotificationEvent
    {
        public Text achievementLabel;
        private List<string> unlockedList = new List<string>();

        void Start()
        {
            PlayerManager.MainPlayer.RegisterObserver(this);
        }

        public void UnlockAchievement(string aAchievement)
        {
            if (!unlockedList.Contains(aAchievement))
            {
                achievementLabel.text = string.Format("Achievement Unlocked: {0}!", aAchievement);
                unlockedList.Add(aAchievement);
            }
            else achievementLabel.text = "";
        }

        public void UpdateNotification(string aMsg)
        {
            UnlockAchievement(aMsg);
        }
    }
}
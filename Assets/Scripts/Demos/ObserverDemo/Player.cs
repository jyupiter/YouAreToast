using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverDemo
{
    public class Player
    {
        private int hp = 10;

        //list of observers
        private List<IOnReceiveNotificationEvent> observerList = new List<IOnReceiveNotificationEvent>();

        //using delegate and event for observers
        private delegate void Notify(string msg);

        public Player(int initHp)
        {
            hp = initHp;
        }

        public bool CheckPlayerAlive()
        {
            return hp > 0;
        }

        public void ReduceHp(int aDmg)
        {
            hp -= aDmg;

            if (hp <= 0) NotifyObservers("DEAD");
            else NotifyObservers("HIT");
        }

        public void RegisterObserver(IOnReceiveNotificationEvent aObserver)
        {
            //add observer to event
            //NotifyEvent += aObserver.Notify;

            //check for duplicate
            if (!observerList.Contains(aObserver))
            {
                //add observer to list
                observerList.Add(aObserver);
            }
        }

        public void UnregisterObserver(IOnReceiveNotificationEvent aObserver)
        {
            //remove observer from event
            //NotifyEvent -= aObserver.Notify;

            //remove observer from list
            observerList.Remove(aObserver);
        }

        private void NotifyObservers(string aMsg)
        {
            //notify observer event
            //NotifyEvent(aMsg);

            //notify observer list
            foreach (IOnReceiveNotificationEvent observer in observerList)
            {
                observer.UpdateNotification(aMsg);
            }
        }
    }
}
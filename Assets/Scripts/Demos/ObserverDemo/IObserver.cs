using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverDemo
{
    public interface IObserver
    {
        void Notify(string aMsg);
    }
}
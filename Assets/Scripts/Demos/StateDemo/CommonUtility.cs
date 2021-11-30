using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SentenceGenerator
{
    public static class CommonUtility
    {
        private const bool showLog = false;

        public static T SelectRandom<T>(List<T> aList)
        {
            //randomly select 1 item from list
            return aList[Random.Range(0, aList.Count)];
        }
        public static void Log(string aLog)
        {
            if (showLog) Debug.Log(aLog);
        }
    }

    public enum ObjectType
    {
        NAME,
        VICTIM,
        LOCATION,
        ITEM
    }
}
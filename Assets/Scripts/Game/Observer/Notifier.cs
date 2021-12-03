using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notifier : MonoBehaviour, IOnReceiveNotificationEvent
{
    public void UpdateNotification(string aMsg)
    {
        Debug.Log(aMsg);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

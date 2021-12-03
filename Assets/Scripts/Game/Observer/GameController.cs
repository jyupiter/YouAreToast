using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public CustomerManager customerManager;
    public SandwichHandler sandwichHandler;

    public static System.Random r = new System.Random();

    public Notifier notifier;
    public Score score;

    void Start()
    {
        CustomerManager.RegisterNotificationObserver(notifier);
        Sandwich.RegisterNotificationObserver(sandwichHandler);
        SandwichHandler.RegisterNotificationObserver(notifier);
        SandwichHandler.RegisterStateObserver(score);

        customerManager.StartCustomerSpawn();
    }

    void Update()
    {
        customerManager.UpdatePatienceText();
    }
}

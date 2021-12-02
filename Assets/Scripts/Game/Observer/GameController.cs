using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public CustomerManager customerManager;
    public SandwichHandler sandwichHandler;

    public static System.Random r = new System.Random();

    public Notifier notifier;

    void Start()
    {
        CustomerManager.RegisterObserver(notifier);
        Sandwich.RegisterObserver(sandwichHandler);
        SandwichHandler.RegisterObserver(notifier);

        customerManager.StartCustomerSpawn();
    }

    void Update()
    {
        customerManager.UpdatePatienceText();
    }
}

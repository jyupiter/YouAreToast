using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject customerManager;

    public static System.Random r = new System.Random();

    public Notifier notifier;

    void Start()
    {
        CustomerManager cm = customerManager.GetComponent<CustomerManager>();

        CustomerManager.RegisterObserver(notifier);
        Sandwich.RegisterObserver(notifier);
        SandwichHandler.RegisterObserver(notifier);

        cm.StartCustomerSpawn();
    }

    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static System.Random r = new System.Random();

    public Notifier notifier;


    void Start()
    {
        CustomerManager.StartCustomerSpawn();
    }

    void Update()
    {
        
    }
}

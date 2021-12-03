using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Patience : PatienceStates
{
    private int minPatience = 40;
    private int maxPatience = 80;

    public static float randomPatience;
    public static float currPatience;

    public void Awake()
    {
        ResetPatienceMeter();
    }

    private void Update() 
    {
        if(currPatience > 0)
            currPatience -= Time.deltaTime;
        else
            currPatience = 0;
        if (currPatience == 0)
        {
            CustomerLeave();
        }
        else if (currPatience <= randomPatience / 3)
            CustomerAngry();
        else
            if (currPatience < randomPatience / 3 * 2)
                CustomerImpatient();
            else
                CustomerHappy();
    }
    public void ResetPatienceMeter()
    {
        randomPatience = GameController.r.Next(minPatience, maxPatience);
        currPatience = randomPatience;
    }
}

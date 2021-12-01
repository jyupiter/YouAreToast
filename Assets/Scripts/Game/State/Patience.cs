using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Patience : MonoBehaviour, ICustomerStates
{
    [SerializeField] private int minPatience = 30;
    [SerializeField] private int maxPatience = 50;

    private float randomPatience;
    private float currPatience;

    public TextMeshProUGUI patienceText;

    public void CustomerHappy()
    {
        Debug.Log("Customer is happy");
        //TODO: Happy expressions
        //TODO: When toast is given to customer: Compare product with expectation.
            //If correct order is given, give high tips
            //If wrong order, give small tips
    }
    public void CustomerImpatient()
    {
        Debug.Log("Customer is impatient");
        //TODO: Impatient expression
        //TODO: When toast is given to customer: Compare product with expectation.
            //If correct order is given, give small tips
            //If wrong order, give no tips
    }
    public void CustomerAngry()
    {
        Debug.Log("Customer is angry");
        //TODO: Angry expression
        //TODO: When toast is given to customer: Compare product with expectation.
            //If correct order is given, give no tips
            //If wrong order, dont even pay for the toast.
    }
    private void Start()
    {
        randomPatience = GameController.r.Next(minPatience, maxPatience);
        currPatience = randomPatience;
    }

    private void Update()
    {
        patienceText.text = currPatience.ToString();
        if(currPatience > 0)
        {
            currPatience -= 1 * Time.deltaTime;
        }
        else
        {
            currPatience = 0;
        }

        if (currPatience <= randomPatience / 3)
        {
            CustomerAngry();
        }
        else if (currPatience < randomPatience / 3 * 2)
        {
            CustomerImpatient();
        }
        else
        {
            CustomerHappy();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level : MonoBehaviour
{
    //TODO: scoring and stuff? idk

    private float maxTimePerDay = 450f;

    public Image maxTime, currTime;

    private bool inKitchen;
    public GameObject kitchenPanel;

    private void Start()
    {
        kitchenPanel.SetActive(false);
        inKitchen = false;
    }

    private void Update()
    {
        maxTimePerDay -= Time.deltaTime;
        if (maxTimePerDay >= 0)
        {
            print("Day ended");
        }
    }

    public void EnterOrExitKitchen()
    {
        if (inKitchen)
        {
            kitchenPanel.SetActive(false);
            inKitchen = false;
        }
        else
        {
            kitchenPanel.SetActive(true);
            inKitchen = true;
        }
    }
}

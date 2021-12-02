using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level : MonoBehaviour
{
    //TODO: scoring and stuff? idk
    private int level;
    public TextMeshProUGUI displayDay;

    private float maxTimePerDay = 450f;
    private float currTime;
    public Image currTimeImage;

    private bool inKitchen;
    public GameObject kitchenPanel;
    public GameObject endDayStats;

    private void Start()
    {
        level = 1;
        currTime = maxTimePerDay;
        inKitchen = false;

        kitchenPanel.SetActive(false);
        endDayStats.SetActive(false);
        displayDay.text = level.ToString();
    }

    private void Update()
    {
        currTime -= Time.deltaTime;
        currTimeImage.fillAmount = currTime / maxTimePerDay;
        if (currTime <= 0)
        {
            endDayStats.SetActive(true);
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

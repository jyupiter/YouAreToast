using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Level : MonoBehaviour
{
    CustomerManager cm;

    private int level;
    public TextMeshProUGUI displayDay;

    public static bool dayHasEnded = false;

    private float maxTimePerDay;
    private float currTime;
    public Image currTimeImage;

    public static bool inKitchen;
    private bool inTooltip;
    public GameObject kitchenPanel, tooltipPanel;
    public GameObject endDayStats;

    public GameObject textCanvas;
    public GameObject customerInfo;

    private void Start()
    {
        cm = gameObject.GetComponent<CustomerManager>();
        level = 1;
        maxTimePerDay = 300f;
        currTime = maxTimePerDay;
        inKitchen = false;
        textCanvas.SetActive(false);

        kitchenPanel.SetActive(false);
        tooltipPanel.SetActive(false);
        endDayStats.SetActive(false);
        displayDay.text = level.ToString();
    }

    private void Update()
    {
        currTime -= Time.deltaTime;
        currTimeImage.fillAmount = currTime / maxTimePerDay;
        if (currTime <= 0)
        {
            dayHasEnded = true;
            customerInfo.SetActive(false);
            cm.HideThisCustomer(); //TODO This causes customers to not spawn when restarted, but fixes end of day layering issues
            endDayStats.SetActive(true);
        }
    }

    public void EnterOrExitKitchen()
    {
        if (inKitchen)
        {
            kitchenPanel.SetActive(false);
            textCanvas.SetActive(false);
            inKitchen = false;
        }
        else
        {
            kitchenPanel.SetActive(true);
            textCanvas.SetActive(true);
            inKitchen = true;
        }
    }

    public void ToolTipButton()
    {
        if (!inTooltip && inKitchen)
        {
            tooltipPanel.SetActive(true);
            inTooltip = true;
        }
        else
        {
            tooltipPanel.SetActive(false);
            inTooltip = false;
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Counter_Scene");
    }
}
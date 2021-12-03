using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Level : MonoBehaviour
{
    private int level;
    public TextMeshProUGUI displayDay;

    private float maxTimePerDay;
    private float currTime;
    public Image currTimeImage;

    public static bool inKitchen;
    public GameObject kitchenPanel;
    public GameObject endDayStats;

    public GameObject textCanvas;

    private void Start()
    {
        level = 1;
        maxTimePerDay = 300f;
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

    public void NextLevel()
    {
        maxTimePerDay = 50f;
        endDayStats.SetActive(false);
        level++;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("Counter_Scene");
    }
}
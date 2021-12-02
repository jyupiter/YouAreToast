using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    //TODO: scoring and stuff? idk



    private bool inKitchen;
    public GameObject kitchenPanel;

    private void Start()
    {
        kitchenPanel.SetActive(false);
        inKitchen = false;
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

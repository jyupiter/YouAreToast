using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    //TODO: scoring and stuff? idk

    public void ChangeToKitchenScene()
    {
        SceneManager.LoadScene("Kitchen_Scene");
    }
    public void ChangeToCounterScene()
    {
        SceneManager.LoadScene("Counter_Scene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toaster : MonoBehaviour
{
    private IEnumerator coroutine;
    bool canContinueToasting = true;

    public void StartToasting(Sandwich sandwich)
    {
        coroutine = ToastWithDelay(5f, sandwich);
        StartCoroutine(coroutine);
    }

    IEnumerator ToastWithDelay(float time, Sandwich sandwich)
    {
        while(canContinueToasting)
        {
            yield return new WaitForSeconds(time);
            canContinueToasting = sandwich.IncreaseToastLevel();
        }
    }

    public void StopToasting()
    {
        if(coroutine != null)
            StopCoroutine(coroutine);
    }
}

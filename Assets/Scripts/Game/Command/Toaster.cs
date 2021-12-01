using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toaster : MonoBehaviour
{
    private IEnumerator coroutine;

    public void StartToasting(Sandwich sandwich)
    {
        coroutine = ToastWithDelay(5f, sandwich);
        StartCoroutine(coroutine);
    }

    IEnumerator ToastWithDelay(float time, Sandwich sandwich)
    {
        bool canContinueToasting = true;

        yield return new WaitForSeconds(time);

        while(canContinueToasting == true)
            canContinueToasting = sandwich.IncreaseToastLevel();
    }

    public void StopToasting()
    {
        if(coroutine != null)
            StopCoroutine(coroutine);
    }
}

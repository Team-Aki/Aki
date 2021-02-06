using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void FadeOutImmediate()
    {
        canvasGroup.alpha = 1;
    }

    public IEnumerator FadeIn(float time)
    {
        while (canvasGroup.alpha > 0) // update every frame but for a limited amount of time(condition)
        {
            canvasGroup.alpha -= Time.deltaTime / time;
            yield return null;
        }
    }

    public IEnumerator FadeOut(float time)
    {
        while (canvasGroup.alpha < 1) // update every frame but for a limited amount of time(condition)
        {
            canvasGroup.alpha += Time.deltaTime / time; //notice how delta time and alpha value are called 
            yield return null;
        }
    }

}


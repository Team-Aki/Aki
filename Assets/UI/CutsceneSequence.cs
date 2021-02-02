using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneSequence : MonoBehaviour
{
    private ScrollingImage ScrollingImage;
    private CanvasGroup cg;

    public Sprite[] fore;
    public Sprite[] back;
    public float[] waiting;

    void Start()
    {
        ScrollingImage = GetComponentInChildren<ScrollingImage>();
        cg = GetComponentInChildren<CanvasGroup>();

        StartCoroutine(ImageScroll(fore,back,waiting));
    }

    IEnumerator ImageScroll(Sprite[] foregrounds, Sprite[] backgrounds, float[] waittimes) //function is called and given arrays with cutsscene images
    {

        for (int i = 0; i < foregrounds.Length; i++)    //goes through each image in sequence
        {
            cg.alpha = 0;

            ScrollingImage.scrollImage(foregrounds[i], backgrounds[i]); //sets image to next in sequence

            for (float t = 0.0f; t < 1.0f; t += 0.1f)   //fades image in
            {
                cg.alpha = t;
                yield return new WaitForSeconds(0.05f);
            }

            cg.alpha = 1;

            yield return new WaitForSeconds(waittimes[i]); //holds on image for set time

            for (float t = 1.0f; t > 0.0f; t -= 0.1f)   //fades image out
            {
                cg.alpha = t;
                yield return new WaitForSeconds(0.05f);
            }

            cg.alpha = 0;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Images : MonoBehaviour
{
    private ScrollingImage ScrollingImage;

    public Sprite[] fore;
    public Sprite[] back;
    public float[] waiting;

    private void Start()
    {
        //cg = GetComponentInChildren<CanvasGroup>();
        ScrollingImage = GetComponentInChildren<ScrollingImage>();
        
    }

    public void PlayImage()
    {
        StartCoroutine(ImageScroll(fore, back, waiting));
    }


    IEnumerator ImageScroll(Sprite[] foregrounds, Sprite[] backgrounds, float[] waittimes) //function is called and given arrays with cutsscene images
    {

        for (int i = 0; i < foregrounds.Length; i++)    //goes through each image in sequence
        {

            ScrollingImage.scrollImage(foregrounds[i], backgrounds[i]); //sets image to next in sequence

            for (float t = 0.0f; t < 1.0f; t += 0.1f)   //fades image in
            {
                yield return new WaitForSeconds(0.05f);
            }


            yield return new WaitForSeconds(waittimes[i]); //holds on image for set time

            for (float t = 1.0f; t > 0.0f; t -= 0.1f)   //fades image out
            {
                yield return new WaitForSeconds(0.05f);
            }


        }
    }
}

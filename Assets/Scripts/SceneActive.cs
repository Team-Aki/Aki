using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SceneActive : MonoBehaviour
{

    [SerializeField] public int imageToShow = 0;
    [SerializeField] public float flipSpeed = 1.0f;
    [SerializeField] public float rotationIncrement = -5.0f;
    [SerializeField] public Vector2 fanIncrement = new Vector2(15, -15);
    [SerializeField] public Vector2 flipAwayOffset = new Vector2(-1, 0);

    public string advanceButton = "Jump";

    Image[] images;
    Vector2 centerPosition;
    float currentImage;
    bool hasFinished;

    public bool TryAdvance()
    {
        if (imageToShow >= images.Length)
            return false;

        //gameObject.SetActive(true);

        imageToShow++;
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        images = GetComponentsInChildren<Image>();
        System.Array.Reverse(images);

        // Remember where the lead image is.
        centerPosition = images[0].rectTransform.anchoredPosition;

        // Update the display of the rest of the stack.
        Layout();

        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(advanceButton))
        {
            TryAdvance();
        }
        if (Mathf.Approximately(imageToShow, currentImage))
        {

            // Is our target card the end of the stack?
            if (imageToShow == images.Length && !hasFinished)
            {
                hasFinished = true;
                Debug.Log("Finished stack!");

               /* // Fire an event - this way you can trigger sounds, scene changes, etc.
                if (OnFinishedStack != null)
                    OnFinishedStack.Invoke();*/
            }

            return;
        }

        // We haven't reached our target card, so animate toward that position.
        // This gives a linear slide, which can look mechanical; you can use easing for more juice.
        currentImage = Mathf.MoveTowards(currentImage, imageToShow, flipSpeed * Time.deltaTime);
        Layout();
    }

    void Layout()
    {
        // Iterate over all cards in the stack.
        for (int i = 0; i < images.Length; i++)
        {
            var image = images[i];

            // For the top card, t = 0. t = 1 for the next card, etc.
            // t < 0 means it's the card that's being removed from the stack.
            float t = i - currentImage;

            // Fade out the cards we've removed from the stack.    
            var color = image.color;
            color.a = Mathf.Clamp01(t + 1f);
            image.color = color;

            var trans = image.rectTransform;
            // Rotate cards so the current card is upright, and later cards fan out.
            trans.localRotation = Quaternion.Euler(0, 0, rotationIncrement * t);

            // If this is the card we're removing, slide to the flipAwayOffset.
            // Otherwise, shift it slightly from the previous card to fan it out.
            trans.anchoredPosition = centerPosition + (t < 0f ?
                Vector2.Lerp(flipAwayOffset, Vector2.zero, t + 1f)
                : Mathf.Pow(t, 0.75f) * fanIncrement);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingImage : MonoBehaviour
{
    public Image foreImage;
    public Image backImage;

    private Vector3 foreSpeed = new Vector3(10, 0);
    private Vector3 backSpeed = new Vector3(5f, 0);

    public void scrollImage(Sprite fore, Sprite back) //sets new image and resets postion
    {
        foreImage.sprite = fore;
        backImage.sprite = back;

        foreImage.transform.localPosition = new Vector3(0, 0, 0);
        backImage.transform.localPosition = new Vector3(0, 0, 0);
    }

    void Update()
    {
        foreImage.transform.localPosition += foreSpeed * Time.deltaTime; //moves foreground
        backImage.transform.localPosition += backSpeed * Time.deltaTime; //moves background
    }
}

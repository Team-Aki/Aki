using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingImage : MonoBehaviour
{
    public Sprite foreground;
    public Sprite background;

    public Image foreImage;
    public Image backImage;

    private Vector3 foreSpeed = new Vector3(100, 0);
    private Vector3 backSpeed = new Vector3(50f, 0);
    
    public void scrollImage(Sprite fore,Sprite back)
    {
        foreImage.sprite = fore;
        backImage.sprite = back;

        foreImage.transform.localPosition = new Vector3(0, 0, 0);
        backImage.transform.localPosition = new Vector3(0, 0, 0);
    }
    
    void Update()
    {
        foreImage.transform.localPosition += foreSpeed * Time.deltaTime;
        backImage.transform.localPosition += backSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            scrollImage(foreground, background);
        }
    }
}

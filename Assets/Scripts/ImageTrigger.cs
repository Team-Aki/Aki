using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTrigger : MonoBehaviour
{
    public Image image;
    public string imageName;

    private void Start()
    {
        image.enabled = false;
    }

}

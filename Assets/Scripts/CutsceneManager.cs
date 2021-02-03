using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CutsceneManager : MonoBehaviour
{
    public Sound[] sounds;
    private ScrollingImage ScrollingImage;
    private CanvasGroup cg;

    public string imageName;
    public Sprite[] fore;
    public Sprite[] back;
    public float waitTime;

    public static CutsceneManager instance;

    void Awake()
    {
        

        cg = GetComponentInChildren<CanvasGroup>();

        //keep one instance
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    void Start()
    {
        ScrollingImage = GetComponentInChildren<ScrollingImage>();

        //StartCoroutine(ImageScroll(fore, back, waiting));
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound" + name + "not found");
            return;
        }
        s.source.Play();
    }

    public void PlayImage(string name)
    {
        Sprite f = Array.Find(fore, foreground => foreground.ToString() == name);
        Sprite b = Array.Find(back, background => background.ToString() == name);

        if (f || b == null)
        {
            Debug.LogWarning("Image" + name + "not found");
            return;
        }
        StartCoroutine(ImageScroll(f, b, waitTime));
    }

    IEnumerator ImageScroll(Sprite foreground, Sprite background, float wait) //function is called and given arrays with cutscene images
    {

        cg.alpha = 0;

        ScrollingImage.scrollImage(foreground, background); //sets image to next in sequence

        for (float t = 0.0f; t < 1.0f; t += 0.1f)   //fades image in
        {
            cg.alpha = t;
            yield return new WaitForSeconds(0.05f);
        }

        cg.alpha = 1;

        yield return new WaitForSeconds(wait); //holds on image for set time

        for (float t = 1.0f; t > 0.0f; t -= 0.1f)   //fades image out
        {
            cg.alpha = t;
            yield return new WaitForSeconds(0.05f);
        }

        cg.alpha = 0;

        
    }
}







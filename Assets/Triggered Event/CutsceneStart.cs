﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneStart : MonoBehaviour
{
    //public Sound sound;
    public Image[] fore;
    public Image[] back;
    public Sound sound;

    Fader fader;

    [SerializeField] float fadeOutTime = 3f;
    [SerializeField] float fadeInTime = 3f;
    [SerializeField] float fadeWaitTime = 3f;

    private Vector3 foreSpeed = new Vector3(5f, 0);
    private Vector3 backSpeed = new Vector3(-5f, 0);

    bool isPlaying;

    private void Awake()
    {
        sound.source = gameObject.AddComponent<AudioSource>();
        sound.source.clip = sound.clip;
        sound.source.volume = sound.volume;
        sound.source.pitch = sound.pitch;
    }

    // Start is called before the first frame update
    void Start()
    {

        isPlaying = false;
        //sound = GetComponent<Sound>();

        fader = FindObjectOfType<Fader>();

        for (int i = 0; i < fore.Length; i++)
        {
            fore[i].GetComponentInChildren<Image>();
            fore[i].transform.localPosition = new Vector3(0, 0, 0);
            fore[i].transform.localPosition = new Vector3(0, 0, 0);
            fore[i].enabled = false;

        }
        
        for (int i = 0; i < back.Length; i++)
        {
            back[i].GetComponentInChildren<Image>();
            back[i].transform.localPosition = new Vector3(0, 0, 0);
            back[i].transform.localPosition = new Vector3(0, 0, 0);
            back[i].enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Transition());
    }

    private IEnumerator Transition()
    {

        sound.source.Play();
        GetComponent<Collider>().enabled = false; //disable colliders as we won't need to play cutscene again
        yield return fader.FadeOut(fadeOutTime);

        EnableImage();

        yield return new WaitForSeconds(fadeWaitTime);

        DisableImage();

        yield return fader.FadeIn(fadeInTime);
    }

    private void EnableImage()
    {
        for (int i = 0; i < fore.Length; i++)
        {
            back[i].enabled = true;
            isPlaying = true;
        }

        for (int i = 0; i < back.Length; i++)
        {
            fore[i].enabled = true;
            isPlaying = true;
        }
    }

    private void DisableImage()
    {
        for (int i = 0; i < fore.Length; i++)
        {
            back[i].enabled = false;
            isPlaying = false;
        }

        for (int i = 0; i < back.Length; i++)
        {
            fore[i].enabled = false;
            isPlaying = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
            ScrollImage();
    }

    private void ScrollImage()
    {
        for (int i = 0; i < fore.Length; i++)
            fore[i].transform.localPosition += foreSpeed * Time.deltaTime; //moves foreground
        

        for (int i = 0; i < back.Length; i++)
            back[i].transform.localPosition += backSpeed * Time.deltaTime; //moves background
    }
}

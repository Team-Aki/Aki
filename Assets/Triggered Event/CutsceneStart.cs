using System;
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
    public CutsceneAudio cutsceneAudio;
    public VFX_Toggle spiritWorld;
    public bool spiritTransition;

    Fader fader;

    [SerializeField] float fadeOutTime = 3f;
    [SerializeField] float fadeInTime = 3f;
    [SerializeField] float fadeWaitTime = 3f;
    [SerializeField] float transitionBetween = 0.01f;

    private Vector3 foreSpeed = new Vector3(5f, 0);
    private Vector3 backSpeed = new Vector3(-5f, 0);

    bool isPlaying;

    private void Awake()
    {
        spiritWorld.GetComponent<VFX_Toggle>();
    }

    // Start is called before the first frame update
    void Start()
    {

        isPlaying = false;
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
        cutsceneAudio.playAudio();
        StartCoroutine(Transition());
    }

    private IEnumerator Transition()
    {
        //sound.source.Play();
        GetComponent<Collider>().enabled = false; //disable colliders as we won't need to play cutscene again
        yield return fader.FadeOut(fadeOutTime);

        EnableFirstImage();

        if (spiritTransition)
            spiritWorld.ActivateSpiritWorld();
        else
            spiritWorld.DeactivateSpiritWorld();

        yield return new WaitForSeconds(fadeWaitTime);

        DisableFirstImage();

        yield return new WaitForSeconds(transitionBetween);

        EnableSecondImage();

        yield return new WaitForSeconds(fadeWaitTime);

        DisableSecondImage();
        cutsceneAudio.stopAudio();
        yield return fader.FadeIn(fadeInTime);
    }

    private void EnableFirstImage()
    {

        back[0].enabled = true;
        fore[0].enabled = true;
        isPlaying = true;
        
    }
    
    private void EnableSecondImage()
    {
        back[1].enabled = true;
        fore[1].enabled = true;
        isPlaying = true;
    }

    private void DisableFirstImage()
    {
        fore[0].enabled = false;
        back[0].enabled = false;
        isPlaying = false;
    }


    private void DisableSecondImage()
    {
        fore[1].enabled = false;
        back[1].enabled = false;
        isPlaying = false;
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

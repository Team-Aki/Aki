using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneStart : MonoBehaviour
{
    //public Sound sound;
    public Image[] fore;
    public Image[] back;

    Fader fader;

    [SerializeField] float fadeOutTime = 3f;
    [SerializeField] float fadeInTime = 3f;
    [SerializeField] float fadeWaitTime = 3f;

    // Start is called before the first frame update
    void Start()
    {

        //sound = GetComponent<Sound>();
        fader = FindObjectOfType<Fader>();

        for (int i = 0; i < fore.Length; i++)
        {
            fore[i].GetComponentInChildren<Image>();
            fore[i].enabled = false;
        }
        
        for (int i = 0; i < back.Length; i++)
        {
            back[i].GetComponentInChildren<Image>();
            back[i].enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Transition());

      
    }

    private IEnumerator Transition()
    {

        //cutscene.PlaySound(soundName);
        GetComponent<Collider>().enabled = false; //disable colliders as we won't need to play cutscene again
        yield return fader.FadeOut(fadeOutTime);

        //cutscene.PlayImage(imageName);

        EnableImage();

        // sceneImage.TryAdvance();

        yield return new WaitForSeconds(fadeWaitTime);

        DisableImage();

        yield return fader.FadeIn(fadeInTime);
    }

    private void EnableImage()
    {
        for (int i = 0; i < fore.Length; i++)
        {
            back[i].enabled = true;
        }

        for (int i = 0; i < back.Length; i++)
        {
            fore[i].enabled = true;
        }
    }

    private void DisableImage()
    {
        for (int i = 0; i < fore.Length; i++)
        {
            back[i].enabled = false;
        }

        for (int i = 0; i < back.Length; i++)
        {
            fore[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

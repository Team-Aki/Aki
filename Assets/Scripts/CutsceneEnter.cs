using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneEnter : MonoBehaviour
{

    [SerializeField] public int scene;
    [SerializeField] float fadeOutTime = 0.3f;
    [SerializeField] float fadeInTime = 0.5f;
    [SerializeField] float fadeWaitTime = 0.4f;

    [SerializeField] Sprite fore;
    [SerializeField] Sprite back;

    CutsceneManager cutscene;

    Fader fader;

    SphereCollider collider;

    Images sceneImage;

    private void Awake()
    {
        //audioTest = GetComponent<AudioSource>();
        cutscene = FindObjectOfType<CutsceneManager>();
        fader = FindObjectOfType<Fader>();
        collider = GetComponent<SphereCollider>();
        sceneImage = GetComponent<Images>();
    }

    private IEnumerator Transition(string soundName)
    {

        cutscene.PlaySound(soundName);
        collider.enabled = false; //disable colliders as we won't need to play cutscene again
        yield return fader.FadeOut(fadeOutTime);

        sceneImage.PlayImage();

        yield return new WaitForSeconds(fadeWaitTime);
        yield return fader.FadeIn(fadeInTime);
    }

    void OnTriggerEnter(Collider other)
    {
        switch (scene)
        {
            case 5:

                //if (other.tag == "Player")

                StartCoroutine(Transition("Windchime"));
 

                break;
            case 4:

                StartCoroutine(Transition("Kick"));

                break;
            case 3:

                //audio.Play("WindChime");
                break;
            case 2:
               
                //audioTest.Play();
                break;
            case 1:
                
                //audioTest.Play();
                break;
            default:
                print("Incorrect ");
                break;
        }


            
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneEnter : MonoBehaviour
{

    public GameObject player;

    [SerializeField]
    public int scene;

    AudioManager audio;
    bool playOnce;

    SphereCollider collider;

    /*[SerializeField]
    public AudioClip clipTest;*/

    /*    [SerializeField]
        public AudioSource audioTest;

        public float volume = 0.5f;

        ;*/
    //bool stopAudio;

    private void Awake()
    {
        //audioTest = GetComponent<AudioSource>();
        audio = FindObjectOfType<AudioManager>();
        collider = GetComponent<SphereCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        //player.SetActive(false); //testing

        /*print("mp3 name " + data[5]["mp3 name"] + " " +
                    "foreground name " + data[5]["foreground name"] + " " +
                    "background name " + data[5]["background name"] + " " +
                    "time " + data[5]["time"]);

        List<Dictionary<string, object>> data = CSVReader.Read("test");*/

        switch (scene)
        {
            case 5:

                audio.Play("WindChime");

                collider.enabled = false; //disable colliders as we won't need to play cutscene again

                break;
            case 4:

                audio.Play("Kick");
                collider.enabled = false;

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

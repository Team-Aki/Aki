using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneEnter : MonoBehaviour
{

    public GameObject player;

    [SerializeField]
    public int scene;

    CutsceneManager cutscene;
    bool playOnce;

    SphereCollider collider;
    
    private ScrollingImage ScrollingImage;
    private CanvasGroup cg;

    /*public Sprite[] fore;
    public Sprite[] back;
    public float[] waiting;*/

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
        cutscene = FindObjectOfType<CutsceneManager>();
        collider = GetComponent<SphereCollider>();
    }

    void OnTriggerEnter(Collider other)
    {

        switch (scene)
        {
            case 5:

                cutscene.PlaySound("Windchime");
                cutscene.PlayImage("Scene5");
           
                collider.enabled = false; //disable colliders as we won't need to play cutscene again

                //stop the player

                break;
            case 4:

                cutscene.PlaySound("Kick");
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


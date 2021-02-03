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

    Images sceneImage;

    private void Awake()
    {
        //audioTest = GetComponent<AudioSource>();
        cutscene = FindObjectOfType<CutsceneManager>();
        collider = GetComponent<SphereCollider>();
        sceneImage = GetComponent<Images>();
    }

    void OnTriggerEnter(Collider other)
    {

        switch (scene)
        {
            case 5:

                cutscene.PlaySound("Windchime");
                sceneImage.PlayImage();
           
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


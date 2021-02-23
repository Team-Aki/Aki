using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrationTrigger : MonoBehaviour
{
    private AudioSource audioSource;
    private bool alreadyPlayed = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(alreadyPlayed == false)
        {
            alreadyPlayed = true;
            audioSource.Play();
        }
    }
}

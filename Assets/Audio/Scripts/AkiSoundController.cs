using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkiSoundController : MonoBehaviour
{
    public AudioClip[] akiSounds;
    public AudioSource audioSource;

    public void playWalk()
    {
        if(audioSource.clip != akiSounds[0])
        {
            audioSource.clip = akiSounds[0];
            audioSource.Play();
        }

        else
        {
            audioSource.UnPause();
        }
    }

    public void playRun()
    {
        if (audioSource.clip != akiSounds[1])
        {
            audioSource.clip = akiSounds[1];
            audioSource.Play();
        }

        else
        {
            audioSource.UnPause();
        }
    }

    public void playSniff()
    {
        if (audioSource.clip != akiSounds[2])
        {
            audioSource.clip = akiSounds[2];
            audioSource.Play();
        }

        else
        {
            audioSource.UnPause();
        }
    }

    public void pauseSFX()
    {
        audioSource.Pause();
    }
}

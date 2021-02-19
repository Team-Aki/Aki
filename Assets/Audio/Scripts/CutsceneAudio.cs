using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CutsceneAudio : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioMixer enviroMixer;
    public AudioMixer cutsceneMixer;

    private float volume;

    public void playAudio()
    {
        cutsceneMixer.SetFloat("Cutscene Volume", -80f);

        audioSource.Play();

        bool result = enviroMixer.GetFloat("Enviroment Volume", out volume);

        if (result)
        {
            StartCoroutine(FadeIn(audioSource, 4f, volume));
        }

        else
        {
            StartCoroutine(FadeIn(audioSource, 4f, 0f));
        }
        
    }

    public void stopAudio()
    {
        StartCoroutine(FadeOut(audioSource, 2f, volume));
    }

    private IEnumerator FadeIn(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = -80f;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            cutsceneMixer.SetFloat("Cutscene Volume", Mathf.Lerp(start, targetVolume, currentTime / duration));
            enviroMixer.SetFloat("Enviroment Volume", Mathf.Lerp(volume, -80f, currentTime / duration));

            yield return null;
        }
        yield break;
    }

    private IEnumerator FadeOut(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = -80f;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            cutsceneMixer.SetFloat("Cutscene Volume", Mathf.Lerp(targetVolume, -80f, currentTime / duration));
            enviroMixer.SetFloat("Enviroment Volume", Mathf.Lerp(start, targetVolume, currentTime / duration));
            yield return null;
        }

        audioSource.Pause();

        yield break;
    }
}

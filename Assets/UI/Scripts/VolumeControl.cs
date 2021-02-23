using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer mixer1;
    public Slider slider1;
    public AudioMixer mixer2;
    public Slider slider2;

    private void Start()
    {
        float volume1;
        float volume2;

        bool result = mixer1.GetFloat("Enviroment Volume", out volume1);

        if (result)
        {
            slider1.value = volume1;
        }

        else
        {
            slider1.value = 0f;
        }

        result = mixer2.GetFloat("SFX Volume", out volume2);

        if (result)
        {
            slider2.value = volume2;
        }

        else
        {
            slider2.value = 0f;
        }
    }

    public void enviromentChange()
    {
        mixer1.SetFloat("Enviroment Volume", slider1.value);
    }

    public void SFXChange()
    {
        mixer2.SetFloat("SFX Volume", slider2.value);
    }
}

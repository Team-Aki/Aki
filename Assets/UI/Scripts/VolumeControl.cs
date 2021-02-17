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

    public void enviromentChange()
    {
        mixer1.SetFloat("Enviroment Volume", slider1.value);
    }

    public void SFXChange()
    {
        mixer2.SetFloat("SFX Volume", slider2.value);
    }
}

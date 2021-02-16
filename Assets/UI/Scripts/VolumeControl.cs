using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer mixer1;
    public Slider slider1;
    
    public void enviromentChange()
    {
        mixer1.SetFloat("Enviroment Volume", slider1.value);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestSounds : MonoBehaviour
{
    public Transform player;
    public AudioSource audioSource;

    void Start()
    {
        
    }


    void Update()
    {
        audioSource.transform.position = player.position;
    }
}

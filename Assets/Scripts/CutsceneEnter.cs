using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneEnter : MonoBehaviour
{

    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        player.SetActive(false); //testing
    }
}

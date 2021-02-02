using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneEnter : MonoBehaviour
{

    public GameObject player;

    [SerializeField]
    public int scene;

    void OnTriggerEnter(Collider other)
    {
        //player.SetActive(false); //testing

        List<Dictionary<string, object>> data = CSVReader.Read("test");

        switch (scene)
        {
            case 5:
                print("mp3 name " + data[5]["mp3 name"] + " " +
                    "foreground name " + data[5]["foreground name"] + " " +
                    "background name " + data[5]["background name"] + " " +
                    "time " + data[5]["time"]);
                break;
            case 4:
                print("mp3 name " + data[4]["mp3 name"] + " " +
                    "foreground name " + data[4]["foreground name"] + " " +
                    "background name " + data[4]["background name"] + " " +
                    "time " + data[4]["time"]);
                break;
            case 3:
                print("mp3 name " + data[3]["mp3 name"] + " " +
                    "foreground name " + data[3]["foreground name"] + " " +
                    "background name " + data[3]["background name"] + " " +
                    "time " + data[3]["time"]);
                break;
            case 2:
                print("mp3 name " + data[2]["mp3 name"] + " " +
                     "foreground name " + data[2]["foreground name"] + " " +
                     "background name " + data[2]["background name"] + " " +
                     "time " + data[2]["time"]);
                break;
            case 1:
                 print("mp3 name " + data[1]["mp3 name"] + " " +
                    "foreground name " + data[1]["foreground name"] + " " +
                    "background name " + data[1]["background name"] + " " +
                    "time " + data[1]["time"]);
                break;
            default:
                print("Incorrect ");
                break;
        }


            
    }
}

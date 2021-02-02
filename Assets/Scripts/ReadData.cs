using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadData : MonoBehaviour
{
    void Awake()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("test");

        for (var i = 0; i < data.Count; i++)
        {
            print("mp3 name " + data[i]["mp3 name"] + " " +
                   "foreground name " + data[i]["foreground name"] + " " +
                   "background name " + data[i]["background name"] + " " +
                   "time " + data[i]["time"]);
        }
    }
}

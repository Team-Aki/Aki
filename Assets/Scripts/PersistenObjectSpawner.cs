using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject persistentObjectPrefab;
    static bool hasSpawned; //static lets the variable live with the application rather than the istance call
                            //It remembers the variable 4ever

    private void Awake()
    {
        if (hasSpawned) return;

        SpawnPersistentObjects();

        hasSpawned = true;
    }

    private void SpawnPersistentObjects()
    {
        GameObject persistentObject = Instantiate(persistentObjectPrefab);
        DontDestroyOnLoad(persistentObject);
    }
}

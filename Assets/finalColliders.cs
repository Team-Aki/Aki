using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalColliders : MonoBehaviour
{
    [SerializeField]
    public GameObject trigger1;

    [SerializeField]
    public GameObject trigger2;

    void OnTriggerEnter()
    {
        trigger1.SetActive(true);
        trigger2.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

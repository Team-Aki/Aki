using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX_Toggle : MonoBehaviour
{
    public bool SpiritOn;

    public GameObject VFXLiving;
    public GameObject VFXSpirit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SpiritOn)
        {
            VFXLiving.gameObject.SetActive(false);
            VFXSpirit.gameObject.SetActive(true);
        }
        else
        {
            VFXLiving.gameObject.SetActive(true);
            VFXSpirit.gameObject.SetActive(false);
        }
    }
}

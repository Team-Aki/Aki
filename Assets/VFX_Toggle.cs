using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VFX_Toggle : MonoBehaviour
{
    private bool SpiritOn;

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

    public void ActivateSpiritWorld()
    {
        SpiritOn = true;
    }

    public void DeactivateSpiritWorld()
    {
        SpiritOn = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class FreeLook : MonoBehaviour
{
    private CinemachineFreeLook freeLookCam;
    // Use this for initialization
    void Start()
    {
        freeLookCam = GetComponent<CinemachineFreeLook>();
    }

    // Update is called once per frame
    void Update()
    {
        freeLookCam.m_XAxis.Value = Input.GetAxis("Controller Right Stick X"); //Right Stick X
        freeLookCam.m_YAxis.Value = Input.GetAxis("Controller Right Stick Y"); //Right Stick Y
    }
}

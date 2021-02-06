using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

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
        freeLookCam.m_XAxis.Value = Input.GetAxis("Right Stick X");
        freeLookCam.m_YAxis.Value = Input.GetAxis("Right Stick Y");

    }
}

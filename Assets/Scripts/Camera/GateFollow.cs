using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GateFollow : MonoBehaviour
{
    CinemachineVirtualCamera gateCam;
    [SerializeField]
    GameObject gate;

    void Start()
    {
        gateCam = GetComponent<CinemachineVirtualCamera>();
        gateCam.LookAt = gate.transform;
        gateCam.enabled = false;
    }
}

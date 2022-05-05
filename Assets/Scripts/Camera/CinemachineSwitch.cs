using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;

public class CinemachineSwitch : MonoBehaviour
{
    [SerializeField]
    private InputAction action;
    [SerializeField]
    private CinemachineVirtualCamera vCam1;
    [SerializeField]
    private CinemachineVirtualCamera vCam2;
    [SerializeField]
    private CinemachineVirtualCamera vCam3;

    private bool cam1 = true;

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void Start()
    {
        action.performed += _ => SwitchCameraPrio();
        
    }

    private void SwitchCameraPrio()
    {
        if (cam1)
        {
            vCam1.Priority = 1;
            vCam2.Priority = 2;
            CinemachineShake.Instance.cam1 = vCam2;
        }

        else
        {
            vCam1.Priority = 2;
            vCam2.Priority = 1;
            CinemachineShake.Instance.cam1 = vCam1;
        }

        cam1 = !cam1;
    }

    public IEnumerator GateCamera(GameObject gate)
    {
        vCam2.enabled = false;
        vCam1.enabled = false;
        vCam3.enabled = true;

        CinemachineShake.Instance.BeginShake(2, 2, 4f);

        yield return new WaitForSeconds(4);

        vCam2.enabled = true;
        vCam1.enabled = true;
        vCam3.enabled = false;

        //TODO STOP MOVMENT for player and owls MW

    }


}

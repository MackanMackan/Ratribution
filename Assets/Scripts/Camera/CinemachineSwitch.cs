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
    float amplitude = 0.5f;
    float frequency = 1f;

    private bool cam1 = true;
    [HideInInspector]
    public bool isGate;

   public PauseMovment pauseMovment;
     
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

    public IEnumerator GateCamera(CinemachineVirtualCamera gateCam)
    {
        pauseMovment.StopMovment(false);

        vCam2.enabled = false;
        vCam1.enabled = false;
        gateCam.enabled = true;
        


        gateCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitude;
        gateCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = frequency;

        yield return new WaitForSeconds(4);

        gateCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        gateCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0;

        pauseMovment.StopMovment(true);

        vCam2.enabled = true;
        vCam1.enabled = true;
        gateCam.enabled = false;

        


    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }
    private float shakeTime;
    
    public CinemachineFreeLook cmfl;

    private void Awake()
    {
        Instance = this;     
    }

    public void Shake(float intensity, float time)
    {
        cmfl.GetRig(0).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = intensity;
        cmfl.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = intensity;
        cmfl.GetRig(3).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = intensity;
        shakeTime = time;
    }

    private void Update()
    {
        if (shakeTime >0)
        {
          shakeTime -= Time.deltaTime;
        }
        
        if (shakeTime<= 0)
        {
            cmfl.GetRig(0).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        }
    }
}

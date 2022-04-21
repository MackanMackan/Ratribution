using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }

    float shakeTime;
    float shakeTimeTotale;
    float startingAmplitude;
    float startingFrequency;

    public CinemachineFreeLook cmfl;

    private void Awake()
    {
        Instance = this;     
    }

   public void CMShake(float amplitude, float frequency, float time)
    {       
        cmfl.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitude;
        cmfl.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = frequency;

        shakeTime = time;
    }

    private void Update()
    {
        if (shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;
        }

        if (shakeTime<= 0)
        {
            CMShake(0f, 0f, 0f);
        }
    }
}

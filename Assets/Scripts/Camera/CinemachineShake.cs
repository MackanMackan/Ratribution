using UnityEngine;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }

    float shakeTime;

   public  CinemachineFreeLook cinemachineFreeLook;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        cinemachineFreeLook = GetComponent<CinemachineFreeLook>();
    }

    public void BeginShake(float amplitude, float frequency, float time)
    {
        StartCoroutine(Shake(amplitude, frequency, time));
    }
    public IEnumerator Shake(float amplitude, float frequency, float time)
    {
        Noise(amplitude, frequency);
        yield return new WaitForSeconds(time);
        Noise(0, 0);
    }
    void Noise(float amplitude, float frequency)
    {       
        cinemachineFreeLook.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitude;
        cinemachineFreeLook.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = frequency;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Shake(20, 20, 0.5f));
        }
    }
}
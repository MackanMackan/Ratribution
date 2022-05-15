using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioHandler : MonoBehaviour
{
    [SerializeField] AudioSource source;
    public void PlayFootStepSFX()
    {
        source.pitch = Random.Range(0.8f,1.4f);
        switch (Random.Range(0, 3))
        {
            case 0:
                source.clip = ServiceLocator.Instance.GetAudioProvider().GetAudioClip("PlayerFootStep1");
                source.Play();
                break;
            case 1:
                source.clip = ServiceLocator.Instance.GetAudioProvider().GetAudioClip("PlayerFootStep2");
                source.Play();
                break;
            case 2:
                source.clip = ServiceLocator.Instance.GetAudioProvider().GetAudioClip("PlayerFootStep3");
                source.Play();
                break;
        }
    }
}

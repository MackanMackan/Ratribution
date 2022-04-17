using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAudioService : IService
{
    public void PlayOneShot(string clipName, Vector3 position, bool randomPitch);
    public void PlayOneShot(AudioClip clip, Vector3 position, bool randomPitch);

    public void PlayLoop(string clipName,Vector3 position);
    public void PlayLoop(AudioClip clip, Vector3 position);

    public void StopLooping(string clipName);
    public void StopLooping(AudioClip clip);
}
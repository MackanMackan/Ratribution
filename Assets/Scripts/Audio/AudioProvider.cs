using System;
using System.Collections.Generic;
using UnityEngine;


public class AudioProvider : IAudioService
{
    private string path;
    private int amountOfSources = 20;
    private float spatialBlend = 0.5f;
    List<AudioSource> audioSources;
    List<AudioClip> audioClips;
    Dictionary<string, AudioClip> audioLibrary;
    GameObject parent;
    public void Initialize()
    {
        path = "Audio/";
        parent = new GameObject("AudioSources");
        CreateAudioSources();
        LoadAudioClipsToList();
    }
    private void CreateAudioSources()
    {

        audioSources = new List<AudioSource>();
        for (int i = 0; i < amountOfSources; i++)
        {
            CreateNewAudioSource();
        }
    }

    private void LoadAudioClipsToList()
    {
        audioLibrary = new Dictionary<string, AudioClip>();
        audioClips = new List<AudioClip>();
        audioClips.AddRange(Resources.LoadAll<AudioClip>(path));
        foreach (var clip in audioClips)
        {
            audioLibrary.Add(clip.name.ToLower(), clip);
        }
    }

    private void AddAudioSourcesToList(AudioSource source)
    {
        audioSources.Add(source);
    }

    public void PlayLoop(string clipName, Vector3 position)
    {
        PlayLoop(audioLibrary[clipName.ToLower()],position);
    }

    public void PlayLoop(AudioClip clip, Vector3 position)
    {
        AudioSource source = GetAvailableAudioSource();
        source.clip = clip;
        source.loop = true;
        source.transform.position = position;
        source.Play();
    }

    public void PlayOneShot(string clipName, Vector3 position, bool randomPitch)
    {
        PlayOneShot(audioLibrary[clipName.ToLower()],position,randomPitch);
    }
    public void PlayOneShot(AudioClip clip, Vector3 position, bool randomPitch)
    {
        AudioSource source = GetAvailableAudioSource();
        source.transform.position = position;
        source.pitch = 1f;
        source.spatialBlend = spatialBlend;
        if (randomPitch) { source.pitch = UnityEngine.Random.Range(0.7f, 1.4f); }
        source.PlayOneShot(clip);
    }
    public void PlayOneShotNoSpatialBlend(string clipName, bool randomPitch)
    {
        PlayOneShotNoSpatialBlend(audioLibrary[clipName.ToLower()],randomPitch);
    }
    public void PlayOneShotNoSpatialBlend(AudioClip clip, bool randomPitch)
    {
        AudioSource source = GetAvailableAudioSource();
        source.pitch = 1f;
        source.spatialBlend = 0;
        if (randomPitch) { source.pitch = UnityEngine.Random.Range(0.7f, 1.4f); }
        source.PlayOneShot(clip);
    }
    private AudioSource GetAvailableAudioSource()
    {
        foreach (var source in audioSources)
        {
            if (!source.isPlaying)
            {
                return source;
            }
        }
        return CreateNewAudioSource();
    }

    private AudioSource CreateNewAudioSource()
    {
        AudioSource source = new GameObject("AudioSource (created at runtime)").AddComponent<AudioSource>();
        source.transform.SetParent(parent.transform);
        source.spatialBlend = spatialBlend;
        source.maxDistance = 4000f;
        AddAudioSourcesToList(source);
        return source;
    }


    public void StopLooping(string clipName)
    {
        throw new System.NotImplementedException();
    }

    public void StopLooping(AudioClip clip)
    {
        throw new System.NotImplementedException();
    }

    public void Uninitialize()
    {
        foreach (var source in audioSources)
        {
            MonoBehaviour.Destroy(source);
        }
        audioSources.Clear();
        audioClips.Clear();
        audioLibrary.Clear();
    }
}
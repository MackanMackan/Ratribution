using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FightingAudioHandler : MonoBehaviour
{
    public static FightingAudioHandler Instance { get { return instance; } }
    private static FightingAudioHandler instance;
    PlayerInputActions playerControls;
    InputAction punch;
    [SerializeField] List<AudioClip> clips;
    [SerializeField] AudioSource source;
    float activeClipTime = 0;
    float timeUntilInactive = 3;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        playerControls = new PlayerInputActions();
        punch = playerControls.Player.Fire;
       
    }
    private void Start()
    {
        punch.Enable();
        punch.started += ChangeFightMusicActive;
        punch.canceled += ChangeFightMusicInactive;
    }
    public void ChangeFightMusicActive(InputAction.CallbackContext callback)
    {
        if(IsInvoking(nameof(DoInactiveMusic))) { CancelInvoke(nameof(DoInactiveMusic)); }
        activeClipTime = source.time;
        source.clip = clips[0];
        source.Play();
        source.time = activeClipTime;
    }

    public void ChangeFightMusicInactive(InputAction.CallbackContext callback)
    {
        Invoke(nameof(DoInactiveMusic), timeUntilInactive);
    }
    void DoInactiveMusic()
    {
        activeClipTime = source.time;
        source.clip = clips[1];
        source.Play();
        source.time = activeClipTime;
    }
}

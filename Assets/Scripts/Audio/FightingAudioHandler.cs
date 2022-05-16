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
    InputAction roll;
    InputAction dropBarrel;
    [SerializeField] List<AudioClip> clips;
    [SerializeField] AudioSource source;
    float activeClipTime = 0;
    float timeUntilInactive = 6;

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
        roll = playerControls.Player.Roll;
        dropBarrel = playerControls.Player.DropBarrel;
       
    }
    private void Start()
    {
        StartCoroutine(ActivateAudioTriggers());
    }
    IEnumerator ActivateAudioTriggers()
    {
        yield return new WaitForSeconds(4f);
        punch.Enable();
        punch.started += ChangeFightMusicActive;
        punch.canceled += ChangeFightMusicInactive;

        roll.Enable();
        roll.started += ChangeFightMusicActive;
        roll.canceled += ChangeFightMusicInactive;

        dropBarrel.Enable();
        dropBarrel.started += ChangeFightMusicActive;
        dropBarrel.canceled += ChangeFightMusicInactive;
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

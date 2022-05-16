using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAudioHandler : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioSource sourceRoll;
    PlayerInputActions playerControls;
    InputAction roll;
    float footStepVolume = 0.15f;
    float rollVolume = 0.8f;
    float currentVolume = 0.8f;
    private void Awake()
    {
        playerControls = new PlayerInputActions();
        roll = playerControls.Player.Roll;
    }

    private void Start()
    {
        StartCoroutine(ActivateAudioTriggers());
        CharacterMovement.isOnGround += SFXTouchGroundVolume;
        CharacterMovement.isNotOnGround += SFXTurnOFVolume;
    }
    IEnumerator ActivateAudioTriggers()
    {
        yield return new WaitForSeconds(4f);
        roll.Enable();
        roll.performed += PlayRollContinous;
        roll.canceled += StopRollContinous;
    }

        public void PlayFootStepSFX()
    {
        source.pitch = Random.Range(0.8f,1.4f);
        source.volume = footStepVolume;
        currentVolume = footStepVolume;
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
    public void PlayRollSFX()
    {
        Debug.Log("Roll SFX!");
        source.volume = rollVolume;
        currentVolume = rollVolume;
        source.pitch = Random.Range(0.8f, 1.4f);
        source.clip = ServiceLocator.Instance.GetAudioProvider().GetAudioClip("PlayerRoll1");
        source.Play();

    }
    public void PlayRollContinous(InputAction.CallbackContext callback)
    {
        sourceRoll.Play();
    }
    public void StopRollContinous(InputAction.CallbackContext callback)
    {
        sourceRoll.Stop();
    }

    void SFXTouchGroundVolume()
    {
        source.volume = currentVolume;
        sourceRoll.volume = 1;
    }
    void SFXTurnOFVolume()
    {
        source.volume = 0;
        sourceRoll.volume = 0;
    }
}

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
    float rollStepVolume = 0.5f;
    float rollContinousVolume = 0.6f;
    float currentVolume = 0.8f;
    Animator animator;

    [SerializeField] ParticleSystem jumpParticles;
    private void Awake()
    {
        playerControls = new PlayerInputActions();
        roll = playerControls.Player.Roll;
    }

    private void Start()
    {
        CharacterMovement.isOnGround += SFXTouchGroundVolume;
        CharacterMovement.isNotOnGround += SFXTurnOFVolume;
        animator = GetComponent<Animator>();
        sourceRoll.volume = rollContinousVolume;
    }
    private void Update()
    {
        if (animator.GetBool("isRolling"))
        {
            PlayRollContinous();
        }
        else if(!animator.GetBool("isRolling"))
        {
            StopRollContinous();
        }
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
        source.volume = rollStepVolume;
        currentVolume = rollStepVolume;
        source.pitch = Random.Range(0.8f, 1.4f);
        source.clip = ServiceLocator.Instance.GetAudioProvider().GetAudioClip("PlayerRoll1");
        source.Play();

    }
    public void PlayRollContinous()
    {
        if(!sourceRoll.isPlaying)
            sourceRoll.Play();
    }
    public void StopRollContinous()
    {
        if (sourceRoll.isPlaying)
            sourceRoll.Stop();
    }
    public void PlayIntroStepSFX()
    {
        ServiceLocator.Instance.GetAudioProvider().PlayOneShot("ImpactAftermath", transform.position, false);
        ServiceLocator.Instance.GetAudioProvider().PlayOneShot("ImpactAftermath", transform.position, false);
        ServiceLocator.Instance.GetAudioProvider().PlayOneShot("ImpactAftermath", transform.position, false);
        CinemachineShake.Instance.BeginShake(1, 1, 1f);
        jumpParticles.Emit(20);
    }
    void SFXTouchGroundVolume()
    {
        source.volume = currentVolume;
        sourceRoll.volume = rollContinousVolume;
    }
    void SFXTurnOFVolume()
    {
        source.volume = 0;
        sourceRoll.volume = 0;
    }
}

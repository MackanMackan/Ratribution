using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventSender : MonoBehaviour
{
    GameObject player;
    CharacterAttack characterAttack;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        characterAttack = player.GetComponent<CharacterAttack>();
    }

    public void SendSlamTriggerMessageToPlayer()
    {
        characterAttack.ActivateSlamTrigger();
    }

    public void PlayIntroLandingRoarSound()
    {
        ServiceLocator.Instance.GetAudioProvider().PlayOneShot("IntroRoar", transform.position, false);
    }

    private void SetAnimationSpeed(float speed)
    {
        Animator animator = gameObject.GetComponent<Animator>();
        animator.SetFloat("AnimationSpeed", speed);
    }
}

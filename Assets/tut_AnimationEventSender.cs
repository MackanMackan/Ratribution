using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tut_AnimationEventSender : MonoBehaviour
{
    GameObject player;
    CharacterAttack characterAttack;
    Tut_Attack tut_Attack;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        tut_Attack = player.GetComponent<Tut_Attack>();
    }

    public void SendSlamTriggerMessageToPlayer()
    {
        tut_Attack.ActivateSlamTrigger();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationImpact : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    public static bool canBeStopped = true;
    [SerializeField]  float stopTime = 0.1f;
    public void PauseAnimationOnImpact(Transform playerTransform, Transform hitterTransform)
    {
        if (canBeStopped)
        {
            StartCoroutine(StopAnimation());
            GameObject particleSystem = ParticleSystemServiceLocator.Instance.GetImpactParticleSystem().GetNewParticleSystem();
            particleSystem.transform.position = hitterTransform.position;
            particleSystem.transform.rotation = playerTransform.rotation;
            ParticleSystem particles = particleSystem.GetComponent<ParticleSystem>();
        }
    }
    IEnumerator StopAnimation()
    {
        canBeStopped = false;
        //Stop animation
        playerAnimator.speed = 0f;
        yield return new WaitForSeconds(stopTime);
        //Start animation again
        playerAnimator.speed = 1f;
    }
}

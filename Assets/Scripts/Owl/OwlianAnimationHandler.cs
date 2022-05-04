using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlianAnimationHandler : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

   public void DoRunAnimation(float movementSpeed)
    {
        animator.SetFloat("MovementSpeed", movementSpeed);
    }
    public void DisableAnimator()
    {
        animator.enabled = false;
    }
    public void DoAttackAnimation()
    {
        animator.SetBool("Attacking", true);
    }
    public void StopAttackAnimation()
    {
        animator.SetBool("Attacking", false);
    }
}

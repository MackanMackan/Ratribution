using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMixing : MonoBehaviour
{
    private Animator animator;

    public Animation running;
    public Transform hips;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (animator.GetBool("isRunning"))
        {

        }
    }

}

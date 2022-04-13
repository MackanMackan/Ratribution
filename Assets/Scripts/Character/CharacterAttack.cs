using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public delegate void fireButton();

public class CharacterAttack : MonoBehaviour
{
    public event fireButton fireButton;

    private PlayerInputActions playerControls;
    private InputAction actionInput;

    [SerializeField] GameObject hitter;
    [SerializeField] GameObject animatorParentObj;

    private Animator animator;
    private Animation anim;

    private Rigidbody hitterRB;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
        actionInput = playerControls.Player.Fire;
    }

    private void Start()
    {
        hitterRB = hitter.GetComponent<Rigidbody>();
        animator = animatorParentObj.GetComponent<Animator>();
        anim = animatorParentObj.GetComponent<Animation>();

        actionInput.performed += MeleeAttack;
    }

    private void OnEnable()
    {
        actionInput.Enable();
    }

    private void OnDisable()
    {
        actionInput.Disable();
    }

    private void MeleeAttack(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("Hej");
        animator.SetBool("punching", true);
        
        animator.SetBool("punching", false);
    }
}

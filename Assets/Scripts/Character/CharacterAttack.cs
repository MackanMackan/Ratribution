using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAttack : MonoBehaviour
{
    private PlayerInputActions playerControls;
    private InputAction fireInput;
    private InputAction fire2Input;

    private CharacterMovement characterMovement;

    public GameObject hitterR;
    public GameObject hitterL;
    public GameObject hitterKick;
    [SerializeField] GameObject animatorParentObj;

    private Animator animator;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
        fireInput = playerControls.Player.Fire;
        fire2Input = playerControls.Player.Fire2;
    }

    private void Start()
    {
        hitterR.SetActive(false);
        hitterL.SetActive(false);
        hitterKick.SetActive(false);

        characterMovement = GetComponent<CharacterMovement>();
        animator = animatorParentObj.GetComponent<Animator>();

        fireInput.started += StartPunching;
        fireInput.canceled += StopPunching;

        fire2Input.started += StartKicking;
        fire2Input.canceled += StopKicking;
    }

    private void OnEnable()
    {
        fireInput.Enable();
        fire2Input.Enable();
    }

    private void OnDisable()
    {
        fireInput.Disable();
        fireInput.Disable();
    }

    private void StartPunching(InputAction.CallbackContext callbackContext)
    {
        animator.SetBool("isPunching", true);
        characterMovement.playerMoveForce = characterMovement.punchingMoveForce;
    }
    private void StartKicking(InputAction.CallbackContext callbackContext)
    {
        animator.SetBool("isKicking", true);
        //stop speed

    }

    private void StopPunching(InputAction.CallbackContext callbackContext)
    {
        animator.SetBool("isPunching", false);
        characterMovement.playerMoveForce = characterMovement.runningMoveForce;
    }

    private void StopKicking(InputAction.CallbackContext callbackContext)
    {
        animator.SetBool("isKicking", false);
        //reset to punching speed, if still punching else running speed
    }

    private void TurnOffPunches()
    {
        hitterR.SetActive(false);
        hitterL.SetActive(false);
        hitterKick.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAttack : MonoBehaviour
{
    private PlayerInputActions playerControls;
    private InputAction fireInput;
    private InputAction fire2Input;

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

    private void MeleeAttack(InputAction.CallbackContext callbackContext)
    {
        animator.SetTrigger("PunchT");
    }
    private void StartPunching(InputAction.CallbackContext callbackContext)
    {
        animator.SetBool("isPunching", true);
    }
    private void StartKicking(InputAction.CallbackContext callbackContext)
    {
        animator.SetBool("isKicking", true);
    }

    private void StopPunching(InputAction.CallbackContext callbackContext)
    {
        animator.SetBool("isPunching", false);
    }

    private void StopKicking(InputAction.CallbackContext callbackContext)
    {
        animator.SetBool("isKicking", false);
    }

    private void TurnOffPunches()
    {
        hitterR.SetActive(false);
        hitterL.SetActive(false);
        hitterKick.SetActive(false);
    }
}

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
    //Hitter hitterScript;

    private Animator animator;

    private Rigidbody hitterRB;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
        fireInput = playerControls.Player.Fire;
        fire2Input = playerControls.Player.Fire2;
    }

    private void Start()
    {
        //hitterRB = hitter.GetComponent<Rigidbody>();
        hitterR.SetActive(false);
        hitterL.SetActive(false);
        hitterKick.SetActive(false);

        animator = animatorParentObj.GetComponent<Animator>();

        //actionInput.performed += MeleeAttack;
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
        //hitter.SetActive(true);
        animator.SetTrigger("PunchT");

        //if (hitterScript == null)
        //    hitterScript = hitter.GetComponent<Hitter>();
        //
        //hitterScript.GetNewHitID();
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

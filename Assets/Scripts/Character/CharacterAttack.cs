using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAttack : MonoBehaviour
{
    private PlayerInputActions playerControls;
    private InputAction actionInput;

    public GameObject hitterR;
    public GameObject hitterL;
    [SerializeField] GameObject animatorParentObj;
    //Hitter hitterScript;

    private Animator animator;

    private Rigidbody hitterRB;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
        actionInput = playerControls.Player.Fire;
    }

    private void Start()
    {
        //hitterRB = hitter.GetComponent<Rigidbody>();
        hitterR.SetActive(false);
        hitterL.SetActive(false);

        animator = animatorParentObj.GetComponent<Animator>();

        //actionInput.performed += MeleeAttack;
        actionInput.started += StartPunching;
        actionInput.canceled += StopPunching;
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

    private void StopPunching(InputAction.CallbackContext callbackContext)
    {
        animator.SetBool("isPunching", false);
    }

    private void TurnOffPunches()
    {
        hitterR.SetActive(false);
        hitterL.SetActive(false);
    }
}

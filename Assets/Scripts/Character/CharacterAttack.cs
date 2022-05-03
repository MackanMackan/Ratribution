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
    public GameObject hitterSlam;
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
        hitterSlam.SetActive(false);

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

        //Slows down player while punching
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

        //Resets player speed after stopping attack
        characterMovement.playerMoveForce = characterMovement.runningMoveForce;
    }
    private void StopKicking(InputAction.CallbackContext callbackContext)
    {
        animator.SetBool("isKicking", false);
    }

    private void DiceRollForAttackVariations()
    {
        int randomNum = Random.Range(1, 10);
        Debug.Log("Diceroll");
        if (randomNum <= 2)
        {
            Debug.Log("Kick");
            animator.SetTrigger("KickT");
            //animator.SetBool("isKicking", true);
        }
        else if (randomNum >= 7)
        {
            Debug.Log("Slam");
            animator.SetTrigger("SlamT");
        }
        else
        {
            Debug.Log("normal punch");
        }
    }


    private void TurnOffPunches()
    {
        hitterR.SetActive(false);
        hitterL.SetActive(false);
        hitterKick.SetActive(false);
    }
}

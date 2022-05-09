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
    public GameObject hitterRoll;
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
        hitterRoll.SetActive(false);

        characterMovement = GetComponent<CharacterMovement>();
        animator = animatorParentObj.GetComponent<Animator>();

        fireInput.started += StartPunching;
        fireInput.canceled += StopPunching;
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
    private void StopPunching(InputAction.CallbackContext callbackContext)
    {
        animator.SetBool("isPunching", false);

        //Resets player speed after stopping attack
        characterMovement.playerMoveForce = characterMovement.runningMoveForce;
    }

    private void DiceRollForAttackVariations()
    {
        int randomNum = Random.Range(1, 100);
        if (randomNum <= 5)
        {
            Debug.Log("Kick");
            animator.SetTrigger("KickT");
        }
        else if (randomNum >= 85)
        {
            Debug.Log("Slam");
            animator.SetTrigger("SlamT");
        }
    }
    public void ActivateSlamTrigger()
    {
        hitterSlam.SetActive(true);
        characterMovement.PushCharacterForwardWhenSlamming();
    }

}

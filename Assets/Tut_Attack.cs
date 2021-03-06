using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tut_Attack : MonoBehaviour
{
    private PlayerInputActions playerControls;
    private InputAction fireInput;
    private InputAction fire2Input;
    private InputAction rollInput;

    //private CharacterMovement characterMovement;
    Movment_tut movment_Tut;

    public GameObject hitterRoll;
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
        rollInput = playerControls.Player.Roll;
    }

    private void Start()
    {
        hitterRoll = GameObject.FindGameObjectWithTag("PlayerHitterRoll");

        hitterRoll.SetActive(false);
        hitterR.SetActive(false);
        hitterL.SetActive(false);
        hitterKick.SetActive(false);
        hitterSlam.SetActive(false);

        movment_Tut = GetComponent<Movment_tut>();
        animator = animatorParentObj.GetComponent<Animator>();

        fireInput.started += StartPunching;
        fireInput.canceled += StopPunching;
        //rollInput.performed += ActivateRollHitter;
    }

    private void OnEnable()
    {
        fireInput.Enable();
        fire2Input.Enable();
        rollInput.Enable();
    }

    private void OnDisable()
    {
        fireInput.Disable();
        fireInput.Disable();
        rollInput.Disable();
    }

    private void StartPunching(InputAction.CallbackContext callbackContext)
    {
        animator.SetBool("isPunching", true);

        //Slows down player while punching
        movment_Tut.playerMoveForce = movment_Tut.punchingMoveForce;
    }
    private void StopPunching(InputAction.CallbackContext callbackContext)
    {
        animator.SetBool("isPunching", false);

        //Resets player speed after stopping attack
        movment_Tut.playerMoveForce = movment_Tut.runningMoveForce;
    }

    private void DiceRollForAttackVariations()
    {
        int randomNum = Random.Range(1, 100);
        if (randomNum <= 5)
        {
            animator.SetTrigger("KickT");
        }
        else if (randomNum >= 85)
        {
            animator.SetTrigger("SlamT");
        }
    }

    public void ActivateSlamTrigger()
    {
        hitterSlam.SetActive(true);
        //characterMovement.PushCharacterForwardWhenSlamming();
    }

}

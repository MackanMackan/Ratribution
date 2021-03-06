using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Movment_tut : MonoBehaviour
{
    [Header("Floats")]
    public float playerMoveForce;
    public float runningMoveForce = 10;
    public float punchingMoveForce = 2.0f;
    public float slamForce;
    public float turnSpeed = 6.0f;
    public float jumpPower = 50.0f;
    public float rayDistance = 1.0f;
    public float stopSpeed = 1.0f;
    public float stamina = 100f;
    public float enableRollAtStamina = 100f;
    public float rollCooldown = 0f;
    public float rollResetCooldown = 5f;

    [Header("Bools")]
    [SerializeField] bool isGrounded;
    [SerializeField] bool walkingUpSlope;
    public bool isSlowedByRollImpact;
    public bool fatigued = false;

    [Header("Misc")]
    [SerializeField] GameObject animatorParentObj;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Slider staminaBar;

    private Vector2 moveDir;
    private Vector3 resetV;
    private Vector3 camCompensatedMoveDir;

    private float targetAngleY;
    private float targetAngleX;

    private Transform CharaCam;

    private PlayerInputActions playerControls;
    private InputAction moveInput;
    private InputAction jumpInput;
    private InputAction rollInput;

    Tut_Attack tut_Attack;
    private Rigidbody rb;
    public Animator animator;

    [SerializeField] ParticleSystem jumpParticles;

    IntroLanding introLanding;

    public event isGrounded isOnGround2;
    public event isNotGrounded isNotOnGround2;
    private void Awake()
    {
        playerControls = new PlayerInputActions();
        moveInput = playerControls.Player.Move;
        jumpInput = playerControls.Player.Jump;
        rollInput = playerControls.Player.Roll;

        //Movement
        moveInput.performed += cntxt => moveDir = cntxt.ReadValue<Vector2>();
        moveInput.canceled += cntxt => moveDir = Vector2.zero;

        jumpInput.performed += Jump;
        rollInput.performed += RollingStone;

        introLanding = FindObjectOfType<IntroLanding>();
    }

    private void Start()
    {
        playerMoveForce = runningMoveForce;
        rb = GetComponent<Rigidbody>();
        CharaCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        animator = animatorParentObj.GetComponent<Animator>();
        tut_Attack = GetComponent<Tut_Attack>();
       // staminaBar = GameObject.FindGameObjectWithTag("StaminaBar").GetComponent<Slider>();

        //Sets stronger gravity for all rigidbodies in the scene
        Physics.gravity = new Vector3(0, -40f, 0);
       
    }

    public void OnEnable()
    {
        moveInput.Enable();
        jumpInput.Enable();
        rollInput.Enable();
    }

    private void OnDisable()
    {
        moveInput.Disable();
        jumpInput.Disable();
        rollInput.Disable();
    }


    private void FixedUpdate()
    {
        CheckIfPlayerIsFallingAndPlayAnimation();
        Movement();
        staminaDrain();
       // CancelRollOnceOutOfStamina();
    }

    public Vector3 GetMoveInput()
    {
        return new Vector3(moveDir.x, 0, moveDir.y);
    }

    private void SlopeCompensation()
    {
        //Calculate surface angle and use it to compensate rotation
        RaycastHit hit;
        RaycastHit compareHit;
        Vector3 localOffset = new Vector3(0, 20, 10);

        //Get surface angle under player
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundLayer) && isGrounded)
        {
            targetAngleX = Mathf.Atan2(hit.normal.x, hit.normal.y) * Mathf.Rad2Deg;
        }

        //Check ahead of player if heading up slope or down slope
        if (Physics.Raycast(transform.TransformPoint(localOffset), Vector3.down, out compareHit, groundLayer))
        {
            //Height check
            if (compareHit.point.y > transform.position.y)
            {
                walkingUpSlope = true;
            }
            else if (compareHit.point.y < transform.position.y)
            {
                walkingUpSlope = false;
            }
        }
        //Clamps targetangle to avoid extreme rotations
        targetAngleX = Mathf.Clamp(targetAngleX, -20f, 20f);
    }
    private void CameraLookRotation()
    {
        //Rotate towards input dir.
        targetAngleY = Mathf.Atan2(GetMoveInput().x, GetMoveInput().z) * Mathf.Rad2Deg + CharaCam.eulerAngles.y;
    }
    private void Rotation()
    {
        if (moveDir != Vector2.zero)
        {
            camCompensatedMoveDir = Quaternion.Euler(targetAngleX, targetAngleY, 0f) * Vector3.forward;
            Quaternion q = Quaternion.LookRotation(camCompensatedMoveDir, Vector3.up);
            transform.localRotation = Quaternion.Lerp(transform.rotation, q, Time.fixedDeltaTime * turnSpeed);
        }
    }

    private void CheckIfPlayerIsFallingAndPlayAnimation()
    {
        if (rb.velocity.y < -10 && !isGrounded)
        {
            animator.SetBool("isFalling", true);
        }
        else if (rb.velocity.y < -5 && isGrounded)
        {
            animator.SetTrigger("LandingT");
        }
        else
        {
            animator.SetBool("isFalling", false);
        }
    }

    private void Movement()
    {
        SlopeCompensation();
        CameraLookRotation();
        Rotation();
        GroundCheck();

        resetV = new Vector3(0, rb.velocity.y, 0);

        if (GetMoveInput().magnitude >= 0.1f)
        {
            if (animator.GetBool("isRolling"))
            {
                camCompensatedMoveDir = playerMoveForce * Time.fixedDeltaTime * camCompensatedMoveDir * 150;
            }
            else
            {
                camCompensatedMoveDir = playerMoveForce * Time.fixedDeltaTime * camCompensatedMoveDir * 100;
            }

            rb.velocity = new Vector3(camCompensatedMoveDir.x, rb.velocity.y, camCompensatedMoveDir.z);
            animator.SetBool("isRunning", true);
        }
        else
        {
            //Disney On Ice hate campaign
            rb.velocity = resetV;
            animator.SetBool("isRunning", false);
            animator.SetBool("isRolling", false);
            tut_Attack.hitterRoll.SetActive(false);
        }
    }
    private void staminaDrain()
    {
        if (animator.GetBool("isRolling"))
        {
            if (stamina > 0)
            {
                stamina -= 10f * Time.fixedDeltaTime;
            }
        }
        else if (!animator.GetBool("isRolling") && stamina < 100)
        {
            stamina += 10f * Time.fixedDeltaTime;
            tut_Attack.hitterRoll.SetActive(false);
        }
        if (stamina == enableRollAtStamina)
        {
            fatigued = false;
        }
       // staminaBar.value = stamina;
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        Debug.Log(staminaBar);
        if (isGrounded)
        {
            Debug.Log("Jump!!");
            animator.SetTrigger("JumpT");
            rb.AddForceAtPosition(jumpPower * Vector3.up * 100, transform.position, ForceMode.Impulse);
        }
    }

    public void PushCharacterForwardWhenSlamming()
    {
        rb.AddForceAtPosition(slamForce * transform.forward * 100, transform.position, ForceMode.Impulse);
    }

    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(transform.position - new Vector3(0, 0.5f, 0), 1f, groundLayer);
        if (isGrounded)
        {
            isOnGround2?.Invoke();
        }
        else
        {
            isNotOnGround2?.Invoke();
        }
    }

    private void RollingStone(InputAction.CallbackContext obj)
    {
        if (!animator.GetBool("isRolling") && stamina > 0 && !fatigued)
        {
            animator.SetBool("isRolling", true);
        }
        else
        {
            animator.SetBool("isRolling", false);
        }
    }

    private void CancelRollOnceOutOfStamina()
    {
        if (stamina < 1)
        {
            fatigued = true;
            animator.SetBool("isRolling", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position - new Vector3(0, 0.5f, 0), 1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Ground")))
        {
            jumpParticles.Emit(20);
        }
    }

}

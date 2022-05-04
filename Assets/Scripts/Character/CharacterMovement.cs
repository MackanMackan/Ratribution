using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [Header("Floats")]
    public float playerMoveForce;
    public float runningMoveForce = 10.0f;
    public float punchingMoveForce = 2.0f;
    public float turnSpeed = 6.0f;
    public float jumpPower = 50.0f;
    public float rayDistance = 1.0f;
    public float stopSpeed = 1.0f;

    [Header("Bools")]
    [SerializeField] bool isGrounded;
    
    [Header("Misc")]
    [SerializeField] GameObject animatorParentObj;
    [SerializeField] LayerMask groundLayer;

    private Vector2 moveDir;
    private Vector3 resetV;

    private float targetAngleY;
    private float targetAngleX;

    private Transform CharaCam;

    private PlayerInputActions playerControls;
    private InputAction moveInput;
    private InputAction jumpInput;

    private Rigidbody rb;
    private Animator animator;

    [SerializeField] ParticleSystem jumpParticles;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
        moveInput = playerControls.Player.Move;
        jumpInput = playerControls.Player.Jump;

        //Movement
        moveInput.performed += cntxt => moveDir = cntxt.ReadValue<Vector2>();
        moveInput.canceled += cntxt => moveDir = Vector2.zero;

        jumpInput.performed += Jump;
    }

    private void Start()
    {
        playerMoveForce = runningMoveForce;
        rb = GetComponent<Rigidbody>();
        CharaCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        animator = animatorParentObj.GetComponent<Animator>();

        //Sets stronger gravity for all rigidbodies in the scene
        Physics.gravity = new Vector3(0, -20f, 0);
    }

    private void OnEnable()
    {
        moveInput.Enable();
        jumpInput.Enable();
    }

    private void OnDisable()
    {
        moveInput.Disable();
        jumpInput.Disable();
    }

    private void FixedUpdate()
    {
        CameraLookRotation();
        SlopeCompensation();
        Movement();
        CheckIfPlayerIsFallingAndPlayAnimation();
    }

    private Vector3 GetMoveInput()
    {
        return new Vector3(moveDir.x, 0, moveDir.y);

    }
    private void CameraLookRotation()
    {
        //Rotate towards input dir.
        targetAngleY = Mathf.Atan2(GetMoveInput().x, GetMoveInput().z) * Mathf.Rad2Deg + CharaCam.eulerAngles.y;
    }
    private void SlopeCompensation()
    {
        //Calculate surface angle and use it to compensate rotation
        RaycastHit hit;
        RaycastHit compareHit;

        //CurrentPos Angle Ray
        //Debug.DrawRay(transform.position, Vector3.down, Color.green, 3f);

        //ComparisonRay
        //Debug.DrawRay(transform.localPosition + new Vector3(0,0,2), Vector3.down, Color.blue, 6f);

        if (Physics.Raycast(transform.position,Vector3.down , out hit, groundLayer) && isGrounded)
        {
            targetAngleX = Mathf.Atan2(hit.normal.x, hit.normal.y) * Mathf.Rad2Deg;
        }

        //Physics.Raycast(transform.localPosition + new Vector3(0, 1, 2), Vector3.down, out compareHit,3f, groundLayer);
        //if (hit.normal.y < compareHit.normal.y)
        //{
        //    Debug.Log("hej");
        //    targetAngleX *= -1;
        //}

        //Clamps targetangle to avoid extreme rotations
        targetAngleX = Mathf.Clamp(targetAngleX, -15f, 15f);
        //Debug.Log(targetAngleX);

    }
    private void Rotation()
    {
        if (moveDir != Vector2.zero)
        {
            Vector3 m = Quaternion.Euler(targetAngleX, targetAngleY, 0f) * Vector3.forward;
            Quaternion q = Quaternion.LookRotation(m, Vector3.up);
            transform.localRotation = Quaternion.Lerp(transform.rotation, q, Time.deltaTime * turnSpeed);
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
        Rotation();
        GroundCheck();

        Vector3 m = Quaternion.Euler(0f, targetAngleY, 0f) * Vector3.forward;
        resetV = new Vector3(0, rb.velocity.y, 0);
        
        if (GetMoveInput().magnitude >= 0.1f)
        {
            m = playerMoveForce * Time.deltaTime * m * 100;

            rb.velocity = new Vector3(m.x, rb.velocity.y, m.z);
            animator.SetBool("isRunning", true);
        }
        else
        {
            //Disney On Ice hate campaign
            rb.velocity = Vector3.Lerp(rb.velocity, resetV, stopSpeed * Time.deltaTime);
            animator.SetBool("isRunning", false);
        }
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        if (isGrounded)
        {
            Debug.Log("Jump!!");
            animator.SetTrigger("JumpT");
            rb.AddForceAtPosition(jumpPower * Vector3.up * 100, transform.position, ForceMode.Impulse);
        }
    }

    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(transform.position - new Vector3(0, 0.5f, 0), 1f, groundLayer);
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

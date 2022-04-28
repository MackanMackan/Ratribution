using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public float playerMoveForce = 20.0f;
    public float turnSpeed = 6.0f;
    public float stopSpeed = 1.0f;
    public float jumpPower = 50.0f;
    public float rayDistance = 1.0f;

    [SerializeField] GameObject animatorParentObj;

    private Vector2 moveDir;
    private Vector3 resetV;
    private float targetAngle;
    private bool isGrounded;

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
        rb = GetComponent<Rigidbody>();
        CharaCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        animator = animatorParentObj.GetComponent<Animator>();
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
        Movement();
    }

    private Vector3 GetMoveInput()
    {
        return new Vector3(moveDir.x, 0, moveDir.y);

    }
    private void CameraLookRotation()
    {
        //Rotate towards input dir.
        targetAngle = Mathf.Atan2(GetMoveInput().x, GetMoveInput().z) * Mathf.Rad2Deg + CharaCam.eulerAngles.y;
    }
    private void Rotation()
    {
        if (moveDir != Vector2.zero)
        {
            Vector3 m = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            Quaternion q = Quaternion.LookRotation(m, Vector3.up);
            transform.localRotation = Quaternion.Lerp(transform.rotation, q, Time.deltaTime * turnSpeed);
        }
    }

    private void Movement()
    {
        Rotation();

        Debug.DrawRay(transform.position, Vector3.down, Color.green, rayDistance);
        Vector3 m = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        resetV = new Vector3(0, rb.velocity.y, 0);
        
        if (GetMoveInput().magnitude >= 0.1f)
        {
            m = playerMoveForce * Time.deltaTime * m * 100;
            m.y = rb.velocity.y;
            rb.velocity = m;
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
        GroundCheck();
        Debug.Log("Jump!!");

        if (isGrounded)
        {
            animator.SetTrigger("JumpT");
            rb.AddForce(jumpPower * Vector3.up, ForceMode.Impulse);
        }
    }

    private void GroundCheck()
    {
        if (Physics.Raycast(transform.position, Vector3.down, rayDistance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        Debug.Log("Checked ground: " + isGrounded);
    }

    private void SlowDown()
    {
        //Slows player down while mid-air or attacking.

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Ground")))
        {
            jumpParticles.Emit(20);
        }
    }
}

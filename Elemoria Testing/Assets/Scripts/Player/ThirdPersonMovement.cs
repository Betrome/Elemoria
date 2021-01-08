using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Animator animator;
    public ComboControls c;
    public MoveSet moves;
    public PlayerControls controls;
    public TargetController t;
    public FloatSO curEr;
//Gravity Variables   
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;
    public bool isGrounded = true;
    public float gravity = -9.81f;
    public bool gravityEnabled = true;
//Movement Variables
    public float speed = 7f;
    public float defSpeed;
    private float horizontal;
    private float vertical;
    private float targetAngle;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    private Vector3 direction;
    private Vector3 moveDir;
    public bool moveEnabled = true;
    public Vector3 move;
    private float deadZone = 0.2f;
    public float rotateMultiplier = 1.0f;
    public float defRotateMultiplier = 1.0f;
    private float minDistance = 1.5f;
//Jump Variables
    public Vector3 velocity;
    public float jumpHeight = 4.0f;
    public float jumpTime = 0.5f;
    public int jumpNumber = 2;
    private int defJumpNumber;
    public bool jumpEnabled = true;
//Air Dodge Variables
    public float airDodgeHeight = 3.0f;
    public float airDodgeSpeed = 8.0f;
    public int airDodgeNumber = 2;
    private int defAirDodgeNumber;
    private float airDodgeTime = 0.5f;
//Dodge Roll Variables
    public float dodgeRollSpeed = 10.0f;
    private float dodgeRollTime = 0.75f;
//Guarding Variables
    private float guardTime = 0.85f;



//Parameters
    int jumpHash = Animator.StringToHash("isJumping");
    int groundedHash = Animator.StringToHash("grounded");
    int landingHash = Animator.StringToHash("isLanding");
    int speedHash = Animator.StringToHash("speed");
    int airDodgeHash = Animator.StringToHash("airDodging");
    int dodgeRollHash = Animator.StringToHash("dodgeRolling");
    int GuardHash = Animator.StringToHash("isGuarding");
    int attackHash = Animator.StringToHash("isAttacking");


//States


    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Jump.performed += ctx => jumping();
        controls.Gameplay.MovePlayer.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.MovePlayer.canceled += ctx => move = Vector3.zero;
        controls.Gameplay.Action.performed += ctx => action();
        
    }

    void Start()
    {
        speed = moves.run.speed;
        c.attackHeight = 0f;

        jumpHeight =  moves.jump.height;
        jumpTime = moves.jump.anim.length/4;

        airDodgeHeight = moves.airDodge.height;
        airDodgeSpeed = moves.airDodge.speed;
        airDodgeTime = moves.airDodge.anim.length;

        dodgeRollSpeed = moves.dodge.speed;
        dodgeRollTime = moves.dodge.anim.length/3.8f;

        guardTime = moves.guard.anim.length/2;

        defJumpNumber = jumpNumber;
        defAirDodgeNumber = airDodgeNumber;
        defSpeed = speed;
    }

    void Update()
    {
//Ground Check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        animator.SetBool(groundedHash, isGrounded);
        animator.SetFloat(speedHash, speed);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            animator.SetTrigger(landingHash);
            animator.ResetTrigger(jumpHash);
            animator.ResetTrigger(airDodgeHash);
            jumpNumber = defJumpNumber;
            airDodgeNumber = defAirDodgeNumber;
        }
        else if(!isGrounded && velocity.y <0)
        {
            animator.ResetTrigger(landingHash);
        }

//Moving
        horizontal = move.x;
        vertical = move.y;
        direction = new Vector3(horizontal, 0f, vertical);

        
        if(direction.magnitude > deadZone && moveEnabled)
        {
            curEr.value += moves.run.radiation / 100f;
            targetAngle = Mathf.Atan2(direction.x, direction.z) * rotateMultiplier * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * (Vector3.forward + (Vector3.up * c.attackHeight));
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            
        }
        else if(direction.magnitude < deadZone && moveEnabled && (animator.GetCurrentAnimatorStateInfo(0).IsName("GroundAttack") || animator.GetCurrentAnimatorStateInfo(0).IsName("AirAttack")) && (t.lockedOn || t.passiveLock))
        {
            curEr.value += moves.run.radiation / 100f;
            targetAngle = Mathf.Atan2(t.dir.x, t.dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angleY = Mathf.Atan2(0, t.dir.y);
            float tanAngle = Mathf.Atan2(t.player.transform.position.y, t.target.transform.position.y) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0.1f);
            t.dir.y = 0f;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(t.dir), Time.time * 2.5f);

            if(tanAngle < 28 && t.distance > minDistance)
            {
                moveDir = Quaternion.Euler(angleY, angle, 0f) * (Vector3.forward + Vector3.up);
            }
            else if (tanAngle > 30 && t.distance > minDistance)
            {
                moveDir = Quaternion.Euler(angleY, angle, 0f) * (Vector3.forward + Vector3.down);
            }
            
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            
        }
        else
            animator.SetFloat(speedHash, 0f);

//Gravity
        if (gravityEnabled)
        {
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
        


    }

//Jumping
    void jumping()
    {
        if(jumpNumber > 0 && jumpEnabled)
        {
            curEr.value += moves.jump.radiation;
            animator.SetTrigger(jumpHash);
            velocity.y = Mathf.Sqrt (jumpHeight * -2 * gravity);
            controller.Move(velocity * Time.deltaTime);
            animator.ResetTrigger(landingHash);
            isGrounded = false;
            jumpNumber--;
            StartCoroutine(AnimationTime(jumpTime, speed));
        }
    }

//actions
    void action()
    {
//Air Dodging
        if(!isGrounded && airDodgeNumber > 0)
        {
            curEr.value += moves.airDodge.radiation;
            animator.SetTrigger(airDodgeHash);
            velocity.y = Mathf.Sqrt (airDodgeHeight * -2 * gravity);
            controller.Move(velocity * Time.deltaTime); 
            animator.ResetTrigger(landingHash);
            isGrounded = false;
            airDodgeNumber--;
            StartCoroutine(AnimationTime(airDodgeTime, airDodgeSpeed));
        }

//Guarding
        if(isGrounded && direction.magnitude <= 0.25f)
        {
            curEr.value += moves.guard.radiation;
            animator.SetTrigger(GuardHash);
            moveEnabled = false;
            jumpEnabled = false;
            StartCoroutine(AnimationTime(guardTime, 0f));
        }

//Dodge Rolling
        else if(isGrounded && moveEnabled)
        {
            curEr.value += moves.dodge.radiation;
            animator.SetTrigger(dodgeRollHash);
            StartCoroutine(AnimationTime(dodgeRollTime, dodgeRollSpeed));
        }
    }


//Wait for Animation before reverting speed.
    IEnumerator AnimationTime(float x, float y)
    {
        speed = y;
        OnDisable();
        yield return new WaitForSeconds(x);
        OnEnable();
        moveEnabled = true;
        jumpEnabled = true;
        speed = defSpeed;
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Jump.Disable();
        controls.Gameplay.Action.Disable();
    }
}

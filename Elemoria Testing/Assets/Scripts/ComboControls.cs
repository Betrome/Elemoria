using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;

public class ComboControls : MonoBehaviour
{
    public ThirdPersonMovement t;
    public PlayerStats player;
    protected Animator animator;
    protected AnimatorOverrideController aoc;
    public Transform target;
    public GameObject weapon;
    protected Transform trail;

//Attack Variables
    public float attackRange = 0.5f;
    private float attackTime = 0.6f;
    public float attackSpeed = 0.5f;
    public float attackHeight = 0f;
    public float attackPower = 0f;
    public float malice = 0f;
    public float knockback = 0f;
    public float knockup = 0f;
    private float cancelTime = 0.2f;
//unecessary Variables?
    public int finisherNumber = 1;
    private int defFinisherNumber;
    public int attackNumber = 2;
    private int defAttackNumber;
//Generic Variables
    public int clicks;
    private bool canAttack;
    private int comboNumber;
    public bool comboFlag;
    public ComboSO ground1;
    public ComboSO ground2;
    public ComboSO ground3;
    public ComboSO ground4;
    public ComboSO air1;
    public ComboSO air2;
    public ComboSO air3;
    public ComboSO air4;

    private ComboSO ground;
    private ComboSO air;
    public TMP_Text combo;

    public FloatSO curEr;
//Parameters
    int attackHash = Animator.StringToHash("isAttacking");
    int animationHash = Animator.StringToHash("animation");

    void Awake()
    {
        ground = ground1;
        air = air1;
        combo.text = "Down";

        t.controls.Gameplay.Combo1.performed += ctx => ComboSwitcher(ground1, air1, "Down");
        t.controls.Gameplay.Combo2.performed += ctx => ComboSwitcher(ground2, air2, "Right");
        t.controls.Gameplay.Combo3.performed += ctx => ComboSwitcher(ground3, air3, "Up");
        t.controls.Gameplay.Combo4.performed += ctx => ComboSwitcher(ground4, air4, "Left");
        t.controls.Gameplay.Attack1.performed += ctx => Attacking();

    }

    void Start()
    {
        defAttackNumber = attackNumber;
        defFinisherNumber = finisherNumber;
        comboNumber = defAttackNumber + defFinisherNumber;
        clicks = 0;
        canAttack = true;
        comboFlag = false;

        trail = weapon.transform.Find("VFX Trail");
        animator = GetComponent<Animator>();
        aoc = new AnimatorOverrideController();
        aoc.runtimeAnimatorController = animator.runtimeAnimatorController;
    }
    
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("1"))
        {
            t.speed = attackSpeed;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsTag("2"))
        {
            t.speed = t.defSpeed;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsTag("3") && t.isGrounded)
        {
            t.speed = t.dodgeRollSpeed;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsTag("3") && !t.isGrounded)
        {
            t.speed = t.airDodgeSpeed;
        }

        if(animator.GetCurrentAnimatorStateInfo(0).IsName("GroundAttack") || animator.GetCurrentAnimatorStateInfo(0).IsName("AirAttack"))
        {
            trail.gameObject.SetActive(true);
        }
        else
        {
            trail.gameObject.SetActive(false);
        }

    }

//Combo Switching
    void ComboSwitcher(ComboSO g, ComboSO a, string t)
    {
        if (g.attacks[clicks] != null)
        {
            ground = g;
        }
        if (a.attacks[clicks] != null)
        {
            air = a;

        }
        combo.text = t;
    }

//Attacking
    void Attacking()
    {
        
        if(!comboFlag)
        {
            if(canAttack && clicks == 0)
            {
                if(t.isGrounded)
                {
                    aoc["Attack_Vertical"] = ground.attacks[clicks].anim;
                    animator.runtimeAnimatorController = aoc;
                    attack(ground.attacks[clicks]);
                }
                else if(!t.isGrounded)
                {
                    t.gravityEnabled = false;
                    aoc["Air_Attack_Vertical"] = air.attacks[clicks].anim;
                    animator.runtimeAnimatorController = aoc;
                    attack(air.attacks[clicks]);
                }
            }
        }
        else
        {
            if (canAttack && clicks < comboNumber && !t.isGrounded)
            {
                clicks++;
                t.gravityEnabled = false;
                aoc["Air_Attack_Vertical"] = air.attacks[clicks].anim;
                animator.runtimeAnimatorController = aoc;
                attack(air.attacks[clicks]);
            }
            else if (canAttack && clicks < comboNumber && t.isGrounded)
            {
                clicks++;
                aoc["Attack_Vertical"] = ground.attacks[clicks].anim;
                animator.runtimeAnimatorController = aoc;
                attack(ground.attacks[clicks]);
            }
        }
    }

    void comboCheck()
    {
        comboFlag = true;
    }

    void attack(AttackSO x)
    {
        curEr.value += x.radiation;
        canAttack = false;
        comboFlag = false;
        t.jumpEnabled = false;
        attackTime = x.anim.length/2 - x.time;//divided by 2 because of the animationi speed ramp.
        cancelTime = x.time;
        attackSpeed = x.speed;
        attackHeight = x.height;
        t.velocity.y = attackHeight;
        t.speed = attackSpeed;
        t.rotateMultiplier = 0.25f;
        //Power Calculations
        attackPower = x.power + player.strength.value;
        //malice & Knockback
        malice = x.mv;
        knockback = x.knockback;
        knockup = x.knockup;
        //actual attacking stuff
        StartCoroutine(AttackTime(attackTime, cancelTime));
    }



//Wait for Animation before reverting speed.
    IEnumerator AttackTime(float x, float y)
    {
        trail.gameObject.SetActive(true);
        t.animator.SetTrigger(attackHash);
        OnDisable();
        yield return new WaitForSeconds(x);
        OnEnable();
        canAttack = true;
        comboFlag = true;
        yield return new WaitForSeconds(y);
        attackHeight = 0f;
        t.speed = t.defSpeed;
        t.rotateMultiplier = t.defRotateMultiplier;
        t.moveEnabled = true;
    }

    void setComboFlag()
    {
        comboFlag = false;
        clicks = 0;
        t.speed = t.defSpeed;
        t.rotateMultiplier = t.defRotateMultiplier;
        t.jumpEnabled = true;
        if(animator.GetNextAnimatorClipInfo(0)[0].clip.name == "Falling" || animator.GetNextAnimatorClipInfo(0)[0].clip.name == "Air_Dodge")
        {
            t.gravityEnabled = true;
        }
        else
        {
            return;
        }
    }

    void OnEnable()
    {
        t.controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        t.controls.Gameplay.Jump.Disable();
        t.controls.Gameplay.Action.Disable();
    }
}

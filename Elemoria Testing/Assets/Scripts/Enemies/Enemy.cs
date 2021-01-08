using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public EnemySO enemyStats;

    public int level;

    public float maxHp;
    public float curHp;
    public float preChangeHp;
    public EnemyHealthBar healthBar;
    public EnemyMaliceBar maliceBar;

    public Rigidbody rb;

    public bool invulnerable;
    public float malice;
    public float curMalice;
    public float maliceCooldown;
    public float maliceMultiplier;
    float _maliceCooldown;

    public int strength;
    public int magic;
    public int defense;
    public int resistance;

    Transform target;

    public EnemyFinder e;
    public TargetController t;
    public EnemyHpUI ui;
    //UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        enemyStats.level = level;

        enemyStats.SetStats();

        maxHp = enemyStats.maxHp;
        malice = enemyStats.malice;
        strength = enemyStats.strength;
        magic = enemyStats.magic;
        defense = enemyStats.defense;
        resistance = enemyStats.resistance;
        maliceCooldown = enemyStats.maliceCooldown;
        maliceMultiplier = enemyStats.maliceMultiplier;

        curHp = maxHp;

        healthBar = ui.hpUI.GetComponentInChildren<EnemyHealthBar>();
        healthBar.SetMaxHealth(maxHp);

        maliceBar = ui.hpUI.GetComponentInChildren<EnemyMaliceBar>();
        maliceBar.SetMaxMalice(malice);

        invulnerable = false;
        curMalice = 0.0f;
        _maliceCooldown = maliceCooldown;
        rb = GetComponent<Rigidbody>();
        target = GameManager.instance.player.transform;
        //agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        if(curMalice <= 0)
        {
            curMalice = 0;
            maliceCooldown = _maliceCooldown;
            invulnerable = false;
        }
        if(curMalice > 0)
        {
            curMalice -= Time.deltaTime * maliceCooldown;
        }
        
        if(curMalice >= malice)
        {
            if(invulnerable == false)
            {
                curMalice = malice;
                invulnerable = true;
            }
            maliceCooldown *= maliceMultiplier;
        }
        maliceBar.SetMalice(curMalice);
    }

    public void TakeDamage(float damage, float rv, float knockback, Vector3 knockbackDir)
    {
        if(invulnerable == false)
        {
            //play hit animation
            preChangeHp = curHp;
            curHp -= damage;
            healthBar.SetHealth(preChangeHp, curHp);
            curMalice += rv;
            if (curMalice >= malice)
            {
                curMalice = malice;
                invulnerable = true;
                maliceCooldown *= maliceMultiplier;
            }
            maliceBar.SetMalice(curMalice);
            rb.AddRelativeForce(knockbackDir * 150 * knockback);

        }


        if (curHp <= 0)
        {
            Die();
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void Die()
    {
        e.EnemyList.Remove(this.GetComponent<Collider>());
        e.closestEnemy = null;
        t.LockOff();
        Destroy(ui.hpUI);
        Destroy(gameObject);
    }

}

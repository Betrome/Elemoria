using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHits : MonoBehaviour
{
    public GameObject player;
    protected ComboControls c;
    protected Animator animator;

    public Vector3 knockbackDirection;

    void Start()
    {
        animator = player.GetComponent<Animator>();
        c = player.GetComponent<ComboControls>();
    }

    void OnTriggerEnter(Collider other)
    {
        //if the object is not already in the list
        if(other.gameObject.tag == "Enemy" && (animator.GetCurrentAnimatorStateInfo(0).IsName("GroundAttack") || animator.GetCurrentAnimatorStateInfo(0).IsName("AirAttack")))
        {
            knockbackDirection = other.transform.position - player.transform.position + new Vector3(0, c.knockup, 0);
            other.GetComponent<Enemy>().TakeDamage(c.attackPower, c.malice, c.knockback, knockbackDirection);
        }
    }
}

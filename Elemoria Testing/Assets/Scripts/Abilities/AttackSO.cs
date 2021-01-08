using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Abilities", menuName = "Ability/Attack", order = 1)]
public class AttackSO : AbilitySO
{
    public bool grounded;
    public bool finisher;
    public float speed = 2;
    public float height;
    public float power = 5;
    public float knockback = 1;
    public float knockup = 1;
    public float mv = 1;
    public float time = 0.3f;
    public AnimationClip anim;
}

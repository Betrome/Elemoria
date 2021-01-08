using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Abilities", menuName = "Ability/Movement", order = 2)]
public class MovementSO : AbilitySO
{
    public bool grounded;
    public float speed;
    public float height;
    public AnimationClip anim;
}

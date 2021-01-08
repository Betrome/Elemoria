using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Abilities", menuName = "Ability/Ability", order = 1)]
public class AbilitySO : ScriptableObject
{
    public string abilityName;
    public string description;
    public int level;
    public float radiation = 1;
}

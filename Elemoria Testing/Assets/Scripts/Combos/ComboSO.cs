using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Combo", menuName = "Combo", order = 1)]
public class ComboSO : ScriptableObject
{
    public List<AttackSO> attacks;
}

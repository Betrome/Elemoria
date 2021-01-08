using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "moveset", menuName = "Moveset", order = 1)]
public class MoveSet : ScriptableObject
{
    public MovementSO run;
    public MovementSO dodge;
    public MovementSO guard;
    public MovementSO jump;
    public MovementSO airDodge;

}

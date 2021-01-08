using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovementAbilities
{
    public MovementSO ability;

    public MovementAbilities(MovementSO ability)
    {
        this.ability = ability;
    }
}

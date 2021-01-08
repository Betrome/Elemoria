using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PassiveAbilities
{
    public PassiveSO ability;

    public PassiveAbilities(PassiveSO ability)
    {
        this.ability = ability;
    }
}

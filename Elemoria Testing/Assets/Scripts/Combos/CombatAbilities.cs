using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CombatAbilities
{
    public AttackSO combat;

    public CombatAbilities(AttackSO combat)
    {
        this.combat = combat;
    }
}

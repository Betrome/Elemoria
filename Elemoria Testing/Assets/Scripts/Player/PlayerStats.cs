using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]
    public string playerName;
    public IntSO level;
    public IntSO exp;
    public FloatSO maxHp;
    public FloatSO curHp;
    public FloatSO maxEr;
    public FloatSO curEr;
    public FloatSO erRecovery;
    public IntSO strength;
    public IntSO magic;
    public IntSO defense;
    public IntSO resistance;

    public HealthBar healthBar;
    public ErBar erBar;

    [Header("Combat Abilities")]
    public List<CombatAbilities> combat = new List<CombatAbilities>();
    [Header("Movement Abilities")]
    public List<MovementAbilities> movement = new List<MovementAbilities>();
    [Header("Passive Abilities")]
    public List<PassiveAbilities> passives = new List<PassiveAbilities>();

  

    void Start()
    {
        curHp.value = maxHp.value;
        curEr.value = 0f;

        healthBar.SetMaxHealth(maxHp.value);
        erBar.SetMaxRadiation(maxEr.value);

    }

    void Update()
    {
        
        if(curEr.value > 0f)
        {
            curEr.value -= erRecovery.value * Time.deltaTime;
            erBar.SetRadiation(curEr.value);
        }        
    }
}

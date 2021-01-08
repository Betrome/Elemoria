using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "EnemyStats", order = 1)]
public class EnemySO : ScriptableObject
{
    public int level;

    public float hpBase;
    public float maliceBase;
    public int strengthBase;
    public int magicBase;
    public int defenseBase;
    public int resistanceBase;

    public float hpGrowth;
    public float maliceGrowth;
    public float strengthGrowth;
    public float magicGrowth;
    public float defenseGrowth;
    public float resistanceGrowth;

    public float maxHp;
    public float curHp;

    public float malice;
    public float curMalice = 0;
    public float maliceCooldown = 0.25f;
    public float maliceMultiplier = 3.0f;

    public int strength;
    public int magic;
    public int defense;
    public int resistance;

    public void SetStats()
    {
        maxHp = hpBase + level*hpGrowth;
        curHp = maxHp;

        malice = maliceBase + level*maliceGrowth;

        strength = Mathf.RoundToInt(strengthBase + level*strengthGrowth);
        magic = Mathf.RoundToInt(magicBase + level*magicGrowth);
        defense = Mathf.RoundToInt(defenseBase + level*defenseGrowth);
        resistance = Mathf.RoundToInt(resistanceBase + level*resistanceGrowth);
    }
}

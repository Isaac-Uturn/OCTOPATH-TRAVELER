using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Combat Attribute Data", menuName = "Scriptable Object/Combat Attribute Data", order = int.MaxValue)]
public class CombatAttributeData : ScriptableObject
{
    [SerializeField]
    private int maxHP;
    public int MaxHP { get { return maxHP; } }

    [SerializeField]
    private int maxMP;
    public int MaxMP { get { return maxMP; } }

    //Striking Point
    [SerializeField]
    private int maxSTR;
    public int MaxSTR { get { return maxSTR; } }

    //Defensive Point
    [SerializeField]
    private int maxDEF;
    public int MaxDEF { get { return maxDEF; } }

    //Agility Point
    [SerializeField]
    private float maxAGI;
    public float MaxAGI { get { return maxAGI; } }

    [SerializeField]
    private List<CombatSkillData> combatSkillDats = new List<CombatSkillData>(4);
    public List<CombatSkillData> CombatSkillDats { get { return combatSkillDats; } }
}

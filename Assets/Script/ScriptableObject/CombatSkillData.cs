using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    None,
    Damage,
    Restore
}


[System.Serializable]
public struct SkillEffect
{
    public ParticleSystem particleSystem;
    public Vector3 particlePosition;
}

[CreateAssetMenu(fileName = "Combat Skill Data", menuName = "Scriptable Object/Combat Skill Data", order = int.MaxValue)]
public class CombatSkillData : ScriptableObject
{
    [SerializeField]
    private SkillType skillType;
    public SkillType SkillType { get { return skillType; } }

    //Damage or Restore
    [SerializeField]
    private int value;
    public int Value { get { return value; } }

    [SerializeField]
    private SkillEffect skillEffect;
    public SkillEffect SkillEffect { get { return skillEffect; } }
}

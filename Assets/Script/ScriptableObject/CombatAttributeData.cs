using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Combat Attribute Data", menuName = "Scriptable Object/Combat Attribute Data", order = int.MaxValue)]
public class CombatAttributeData : ScriptableObject
{
    [SerializeField]
    private int maxHP;
    public int MaxHP { get { return maxHP; } }

    //Striking Point
    [SerializeField]
    private int maxSP;
    public int MaxSP { get { return maxSP; } }

    //Defensive Point
    [SerializeField]
    private int maxDP;
    public int MaxDP { get { return maxDP; } }
    
    [SerializeField]
    private int damage;
    public int Damage { get { return damage; } }

    [SerializeField]
    private float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AttributeData
{
    [HideInInspector]
    public float baseValue;
    [HideInInspector]
    public float currentValue;

    float GetBaseValue()
    {
        return baseValue;
    }

    float GetCurrentValue()
    {
        return currentValue;
    }

    void SetBaseValue(float value)
    {
        baseValue = value;
    }

    void SetCurrentValue(float value)
    {
        currentValue = value;
    }
}


public class AttributeSet : MonoBehaviour
{
    [SerializeField]
    private CombatAttributeData combatAttribute;
    public CombatAttributeData CombatAttribute { set { combatAttribute = value; } }

    public AttributeData health;
    public AttributeData mana;
    public AttributeData striking;
    public AttributeData defensive;
    public AttributeData agility;

    private void Start()
    {
        health.baseValue = combatAttribute.MaxHP;
        mana.baseValue = combatAttribute.MaxMP;
        striking.baseValue = combatAttribute.MaxSTR;
        defensive.baseValue = combatAttribute.MaxDEF;
        agility.baseValue = combatAttribute.MaxAGI;
    }
}

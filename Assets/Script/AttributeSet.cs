using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AttributeData
{
    public float baseValue;
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
    public AttributeData health;
    public AttributeData striking;
    public AttributeData defensive;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    AttributeSet attributeSet;
    protected CombatComponent combatComponent;

    void Start()
    {
        combatComponent = GetComponent<CombatComponent>();
        attributeSet = GetComponent<AttributeSet>();

        combatComponent.AttributeSet = attributeSet;
    }

    void Update()
    {
        
    }
}

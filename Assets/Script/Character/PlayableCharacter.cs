using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter : Character
{
    protected BoxCollider collider;
    protected Rigidbody rigidBody;
    protected AttributeSet attributeSet;
    protected CombatComponent combatComponent;

    // Start is called before the first frame update
    void Start()
    {
        combatComponent = GetComponent<CombatComponent>();
        attributeSet = GetComponent<AttributeSet>();

        combatComponent.AttributeSet = attributeSet;

        collider = GetComponent<BoxCollider>();
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.freezeRotation = true;
        rigidBody.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

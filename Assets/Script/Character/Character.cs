using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Animator animator;
    protected SpriteRenderer renderer;
    protected BoxCollider collider;
    protected Rigidbody rigidBody;
    protected AttributeSet attributeSet;
    protected CombatComponent combatComponent;

    protected virtual void Start()
    {
        combatComponent = GetComponent<CombatComponent>();
        attributeSet = GetComponent<AttributeSet>();

        combatComponent.attributeSet = attributeSet;

        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider>();
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.freezeRotation = true;
        rigidBody.useGravity = true;

        //animator.SetBool("isCombat", true);
    }
}

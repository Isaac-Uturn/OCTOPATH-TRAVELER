using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayableCharacter : Character
{
    [SerializeField]
    InputActionAsset actions;

    protected BoxCollider collider;
    protected Rigidbody rigidBody;
    protected AttributeSet attributeSet;
    protected CombatComponent combatComponent;

    public bool isPlayer;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        base.Start();

        combatComponent = GetComponent<CombatComponent>();
        attributeSet = GetComponent<AttributeSet>();

        combatComponent.AttributeSet = attributeSet;

        collider = GetComponent<BoxCollider>();
        //collider.isTrigger = true;

        rigidBody = GetComponent<Rigidbody>();
        rigidBody.freezeRotation = true;
        rigidBody.useGravity = true;

        if (true == isPlayer)
        {
            SetPlayer();
        }
    }

    //Playable Character를 Player로 지정
    public virtual void SetPlayer()
    {
        gameObject.AddComponent<MainPlayer>();
        PlayerController controller = gameObject.AddComponent<PlayerController>();
        controller.actions = actions;

        //collider.isTrigger = false;
        enabled = false;
    }
}

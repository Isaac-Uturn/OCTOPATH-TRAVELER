using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class PlayableCharacter : Character
{
    [SerializeField]
    InputActionAsset actions;

    protected BoxCollider _collider;
    protected Rigidbody _rigidBody;
    protected AttributeSet _attributeSet;
    protected CombatComponent _combatComponent;

    [SerializeField]
    bool isPlayer;

    //public Transform charcterTransform;

    //private const string layerName = "Interactable";

    // Start is called before the first frame upda  te
    protected virtual void Start()
    {
        base.Start();

        _combatComponent = GetComponent<CombatComponent>();
        _attributeSet = GetComponent<AttributeSet>();

        _combatComponent.AttributeSet = _attributeSet;

        _collider = GetComponent<BoxCollider>();
        //collider.isTrigger = true;

        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.freezeRotation = true;
        _rigidBody.useGravity = true;

        if (true == isPlayer)
        {
            SetPlayer();
        }

        else
        {
            SetColleague();
        }
    }

    //Playable Character(Main Player)를 Player로 지정
    protected virtual void SetPlayer()
    {
        gameObject.AddComponent<MainPlayer>();
        
        //Interable만 충돌 검사하도록 지정
        Interactor interactor = gameObject.AddComponent<Interactor>();
        interactor.layerMask = 1 << LayerMask.NameToLayer("Interactable");

        PlayerController controller = gameObject.AddComponent<PlayerController>();
        controller.actions = actions;

        //MainPlayer가 PlayerableCharacter를 상속받았으나 상속 구조 제거
        //enabled = false;
    }

    //Playable Character(Colleague)를 Colleague로 지정
    protected virtual void SetColleague()
    {
        Peer peer = gameObject.AddComponent<Peer>();
    }
}

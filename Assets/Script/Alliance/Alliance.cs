using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ALLYSTATE
{
    FowardIdle,
    LeftIdle,
    RightIdle,
    BackIdle,
    Move,
    Combat,
}

public class Alliance : MonoBehaviour
{
    protected ALLYSTATE currentState;

    protected int hp;
    protected int maxHp;
    protected int sp;
    protected int maxSp;

    [SerializeField]
    protected Sprite[] sprites = new Sprite[4];

    protected Animator aAnim;
    protected SpriteRenderer aRenderer;
    protected BoxCollider aCollider;
    protected Rigidbody aRigidBody;

    protected virtual void Start()
    {
        aAnim = GetComponent<Animator>();
        aRenderer = GetComponent<SpriteRenderer>();
        aCollider = gameObject.AddComponent<BoxCollider>();
        aCollider.size = new Vector3(0.5f, 0.66f, 0.5f);
        aRigidBody = gameObject.AddComponent<Rigidbody>();
        aRigidBody.freezeRotation = true;
        aRigidBody.useGravity = true;
    }

    //약점
    //고유 액션
    public ALLYSTATE GetState()
    {
        return currentState;
    }

    public virtual float GetMoveX()
    {
        return 0.0f;
    }

    public virtual float GetMoveY()
    {
        return 0.0f;
    }

}

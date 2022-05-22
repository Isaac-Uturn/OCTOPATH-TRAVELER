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

    //약점
    //고유 액션

    private void Start()
    {
        DontDestroyOnLoad(this);

        currentState = ALLYSTATE.FowardIdle;
    }

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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatComponent : MonoBehaviour, IBattleColleague
{
    public IBattleMediator BattleManager { get; set; }
    
    [HideInInspector]
    public AttributeSet attributeSet = null;

    // Attack 시 공격 대상
    public GameObject Target { get; set; } 

    public ActionType actiontype;

    public ActionType ActionType
    {
        get
        {
            return actiontype;
        }

        set
        {
            actiontype = value;
        }
    }

    bool isAttack = false;

    public void SetBattleManager(IBattleMediator battleManager)
    {
        BattleManager = battleManager;
    }

    public IEnumerator Notify()
    {
        switch (actiontype)
        {
            case ActionType.Skill:
                break;
            case ActionType.Attack:
                yield return Attack();
                break;
            case ActionType.Defanse:
                break;
            case ActionType.Item:
                break;
            case ActionType.Run:
                break;
            default:
                Debug.Log("해당 액션을 동작할 수 없습니다.");
                break;
        }

        yield return null;
    }

    IEnumerator Attack()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = Vector3.zero;

        float alpha = 0.0f;

        while (true)
        {
            transform.position = Vector3.Lerp(startPos, endPos, alpha);
            alpha += Time.deltaTime;

            if (1.0f <= alpha)
            {
                break;
            }

            yield return null;
        }

        yield return AttackComback(startPos);
    }

    IEnumerator AttackComback(Vector3 pos)
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = pos;

        float alpha = 0.0f;

        while (true)
        {
            transform.position = Vector3.Lerp(startPos, endPos, alpha);
            alpha += Time.deltaTime;

            if (1.0f <= alpha)
            {
                break;
            }

            yield return null;
        }
    }

    public void Hit(float damage)
    {

    }
}

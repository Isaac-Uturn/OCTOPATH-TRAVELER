using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatComponent : MonoBehaviour, IBattleColleague
{
    public IBattleMediator BattleManager { get; set; }
    
    AttributeSet attributeSet = null;
    public AttributeSet AttributeSet { get; set; }

    // 상호작용 액션 시 대상
    public CombatComponent Target { get; set; }

    Animator animator;

    public ActionType actionType;
    public ActionType ActionType
    {
        get
        {
            return actionType;
        }

        set
        {
            actionType = value;
        }
    }

    void Start() 
    {
        animator= GetComponent<Animator>();
    }

    public void SetBattleManager(IBattleMediator battleManager)
    {
        BattleManager = battleManager;
    }

    public IEnumerator Notify()
    {
        switch (actionType)
        {
            case ActionType.Skill:
                break;
            case ActionType.Attack:
                yield return Attack();
                break;
            case ActionType.Defense:
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

    public virtual void ChooseRandomAction()
    {
        ActionType[] availableActions = { ActionType.Attack, ActionType.Skill };
        actionType = availableActions[UnityEngine.Random.Range(0, availableActions.Length)];
    }

    IEnumerator Attack()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = Target.transform.position;

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

    public void CombatStart()
    {
        animator.SetBool("isCombat", true);
    }

    public void Hit(float damage)
    {

    }
}

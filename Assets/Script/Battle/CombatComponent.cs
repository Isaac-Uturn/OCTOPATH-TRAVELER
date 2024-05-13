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

    Animator _animator;

    public float attackOffset = 0.0f;

    private ActionType actionType;
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

    protected readonly int hashIsAttackPara = Animator.StringToHash("isAttack");
    protected readonly int hashIsCombatPara = Animator.StringToHash("isComat");

    void Start() 
    {
        _animator= GetComponent<Animator>();
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
                Debug.Log("Skill");
                break;
            case ActionType.Attack:
                Debug.Log("Attack");
                yield return Attack();
                break;
            case ActionType.Defense:
                Debug.Log("Defense");
                break;
            case ActionType.Item:
                Debug.Log("Use item");
                break;
            case ActionType.Run:
                Debug.Log("Run");
                break;
            default:
                Debug.LogError("해당 액션을 동작할 수 없습니다.");
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
        endPos.x += attackOffset;
        
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

        _animator.SetBool(hashIsAttackPara, true);

        float animationTime = _animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationTime);

        _animator.SetBool(hashIsAttackPara, false);

        yield return new WaitForSeconds(0.5f);

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
        _animator.SetBool(hashIsCombatPara, true);
    }

    public void CombatEnd()
    {
        _animator.SetBool(hashIsCombatPara, false);
    }

    public void Hit(float damage)
    {

    }
}

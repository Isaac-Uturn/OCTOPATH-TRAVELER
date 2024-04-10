using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatComponent : MonoBehaviour, IBattleColleague
{
    public IBattleMediator BattleManager { get; set; }
    [HideInInspector]
    public AttributeSet attributeSet = null;

    bool isAttack = false;

    public void SetBattleManager(IBattleMediator battleManager)
    {
        BattleManager = battleManager;
    }

    public float Attack(GameObject target)
    {
        StartCoroutine(AttackMove(target));
        return 10;
    }

    IEnumerator AttackMove(GameObject target)
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = target.transform.position;

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

        BattleManager.Battle();
    }


    public void AttackComback(Transform target)
    {
        StartCoroutine(AttackCombackMove(target));
    }

    IEnumerator AttackCombackMove(Transform target)
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = target.transform.position;

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

        BattleManager.Battle();
    }


    public void Hit(float damage)
    {

    }
}

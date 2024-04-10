using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattleColleague
{
    IBattleMediator BattleManager { get; set; }

    float Attack(GameObject target);

    void Hit(float damage);
}


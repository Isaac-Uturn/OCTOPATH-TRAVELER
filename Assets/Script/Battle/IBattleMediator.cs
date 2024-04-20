using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattleMediator
{
    void AddBattleColleague(IBattleColleague battleColleague);

    IEnumerator Battle();
}
    
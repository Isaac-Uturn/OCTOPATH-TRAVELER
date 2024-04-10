using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattleMediator
{
    void AddCharacter(GameObject character);
    void AddEnemy(GameObject enemy);

    public void Battle();
}

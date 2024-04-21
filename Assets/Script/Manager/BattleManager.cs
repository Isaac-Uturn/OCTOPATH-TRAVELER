using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BattleManager는 Battle 씬에만 존재함.
public class BattleManager : MonoBehaviour, IBattleMediator
{
    public BattleTurn currentTrun = BattleTurn.None;

    [SerializeField]
    BattleUI BattleUI;

    //IBattleColleague로 변경해도 될 거 같음.
    List<IBattleColleague> battleColleagues = new List<IBattleColleague>();
    
    public List<CombatComponent> characters = new List<CombatComponent>();
    public List<CombatComponent> enemies = new List<CombatComponent>();

    int currentActionIndex = 0;

    public delegate void TurnChanged(BattleTurn trun);
    public TurnChanged turnChanged;

    public void Initialized()
    {
        currentTrun = BattleTurn.SelectAction;
        turnChanged(currentTrun);
    }

    public void AddBattleColleague(IBattleColleague colleague)
    {
        battleColleagues.Add(colleague);
    }

    public void AddCharacter(CombatComponent component)
    {
        characters.Add(component);
    }

    public void AddEnemy(CombatComponent component)
    {
        enemies.Add(component);
    }

    public IEnumerator Battle()
    {
        while (true)
        {
            switch (currentTrun)
            {
                //모든 플레이어블 캐릭터가 액션을 선택.
                //적 캐릭터들도 AI에 따라 액션 선택
                case BattleTurn.SelectAction:
                    {
                        currentActionIndex = 0;

                        for (int i = 0; i < enemies.Count; ++i)
                        {
                            enemies[i].ChooseRandomAction();
                        }

                        yield return BattleUI.BattleUIEnable();

                        currentTrun = BattleTurn.Action;
                    }
                    break;

                //속도와 같은 속성에 따라 각 캐릭터 액션
                //if: 액션할 캐릭터가 없다면 다시 Select.
                case BattleTurn.Action:
                    {
                        yield return battleColleagues[currentActionIndex].Notify();
                        
                        currentTrun = BattleTurn.ActionEnd;
                    }
                    break;

                //액션 이후 처리
                case BattleTurn.ActionEnd:
                    {
                        ++currentActionIndex;

                        //적 진영/플레이어 진영 중 둘 하나라도 살아남음
                        if (battleColleagues.Count == currentActionIndex)
                        {
                            currentTrun = BattleTurn.SelectAction;
                        }

                        else
                        {
                            currentTrun = BattleTurn.Action;
                        }
                    }
                    break;

                case BattleTurn.BattleEnd:
                    //yield break;
                    break;

                default:
                    Debug.Log("진행할 수 없는 턴입니다.");
                    break;
            }

            turnChanged(currentTrun);
        }
    }
}
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

    int currentActionIndex = 0;

    public void Initialized()
    {
        currentTrun = BattleTurn.SelectAction;
        BattleUI.currentBattleStateText.text = currentTrun.ToString();
    }

    //씬 전환 시 전투 속 캐릭터들을 초기화한다.
    public void AddBattleColleague(IBattleColleague colleague)
    {
        battleColleagues.Add(colleague);
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
                        yield return BattleUI.BattleUIEnable();

                        currentTrun = BattleTurn.Action;
                        BattleUI.currentBattleStateText.text = currentTrun.ToString();
                    }
                    break;

                //속도와 같은 속성에 따라 각 캐릭터 액션
                //if: 액션할 캐릭터가 없다면 다시 Select.
                case BattleTurn.Action:
                    {
                        yield return battleColleagues[currentActionIndex].Notify();
                        currentTrun = BattleTurn.ActionEnd;

                        BattleUI.currentBattleStateText.text = currentTrun.ToString();
                    }
                    break;

                //액션 이후 처리
                case BattleTurn.ActionEnd:
                    {
                        ++currentActionIndex;
                        BattleUI.currentBattleStateText.text = currentTrun.ToString();

                        //적 진영/플레이어 진영 중 둘 하나라도 살아남음
                        if (battleColleagues.Count == currentActionIndex)
                        {
                            currentTrun = BattleTurn.SelectAction;
                            BattleUI.currentBattleStateText.text = currentTrun.ToString();
                        }
                        else
                        {
                            currentTrun = BattleTurn.Action;
                            BattleUI.currentBattleStateText.text = currentTrun.ToString();
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
        }
    }
}
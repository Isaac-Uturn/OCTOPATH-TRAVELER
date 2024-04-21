using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    public BattleManager BattleManager { get; set; }
    int currentCharacterIndex = 0;

    [SerializeField]
    private Text currentIndexText = null;
    [SerializeField]
    private Text currentBattleStateText = null;

    bool isEnable = false;

    public IEnumerator BattleUIEnable()
    {
        isEnable = true;
        UpdateIndex();

        while (true == isEnable)
        {
            yield return null;
        }
    }

    void NextCharacterSelect()
    {
        ++currentCharacterIndex;

        //모든 전투 캐릭터 액션 선택 완료
        if (currentCharacterIndex == BattleManager.characters.Count)
        {
            isEnable = false;
            currentCharacterIndex += BattleManager.enemies.Count;
        }

        UpdateIndex();
    }

    public void SelectEvnet_Action(int action)
    {
        SelectEvnet_Action((ActionType)action);
    }

    public void SelectEvnet_Action(ActionType action)
    {
        if (false == isEnable)
        {
            return;
        }

        switch (action)
        {
            case ActionType.Skill:
                BattleManager.characters[currentCharacterIndex].ActionType = ActionType.Skill;
                break;
            case ActionType.Attack:
                BattleManager.characters[currentCharacterIndex].ActionType = ActionType.Attack;
                //Target은 일단 첫번째 Enemy
                BattleManager.characters[currentCharacterIndex].Target = BattleManager.enemies[0];
                break;
            case ActionType.Defense:
                BattleManager.characters[currentCharacterIndex].ActionType = ActionType.Defense;
                break;
            case ActionType.Item:
                BattleManager.characters[currentCharacterIndex].ActionType = ActionType.Item;
                break;
            case ActionType.Run:
                BattleManager.characters[currentCharacterIndex].ActionType = ActionType.Run;
                //TODO: BattleManager 관련 기능 구현
                break;
            default:
                Debug.Log("선택할 수 없는 액션을 선택했습니다.");
                break;
        }

        NextCharacterSelect();
    }

    public void UpdateIndex()
    {
        currentIndexText.text = currentCharacterIndex.ToString();
    }

    public void OnTurnChanged(BattleTurn turn)
    {
        currentBattleStateText.text = turn.ToString();

        switch (turn)
        {
            case BattleTurn.SelectAction:
                break;
            case BattleTurn.Action:
                break;
            case BattleTurn.ActionEnd:
                --currentCharacterIndex;
                UpdateIndex();
                break;
            case BattleTurn.BattleEnd:
                break;
            default:
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    //BattleManager�� �Ҵ�
    List<CombatComponent> CombaterList = new List<CombatComponent>();
    int currentIndex = 0;

    public Text currentIndexText = null;
    public Text currentBattleStateText = null;

    bool isEnable = false;

    public void AddCombater(CombatComponent component)
    {
        CombaterList.Add(component);
    }

    public IEnumerator BattleUIEnable()
    {
        isEnable = true;

        while (true == isEnable)
        {
            yield return null;
        }
    }

    void NextCharacterSelect()
    {
        ++currentIndex;
        currentIndexText.text = currentIndex.ToString();

        //��� ���� ĳ���� �׼� ���� �Ϸ�
        if (currentIndex == CombaterList.Count - 1)
        {
            isEnable = false;
        }
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
                CombaterList[currentIndex].ActionType = ActionType.Skill;
                break;
            case ActionType.Attack:
                CombaterList[currentIndex].ActionType = ActionType.Attack;
                break;
            case ActionType.Defanse:
                CombaterList[currentIndex].ActionType = ActionType.Defanse;
                break;
            case ActionType.Item:
                CombaterList[currentIndex].ActionType = ActionType.Item;
                break;
            case ActionType.Run:
                CombaterList[currentIndex].ActionType = ActionType.Run;
                //TODO: BattleManager ���� ��� ����
                break;
            default:
                Debug.Log("������ �� ���� �׼��� �����߽��ϴ�.");
                break;
        }

        NextCharacterSelect();
    }
}
